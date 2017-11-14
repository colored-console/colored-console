// parameters
var versionSuffix = Environment.GetEnvironmentVariable("VERSION_SUFFIX");

// solution specific variables
var xml = File.ReadAllText("src/ColoredConsole/ColoredConsole.csproj");
var doc = new System.Xml.XmlDocument();
doc.LoadXml(xml);
var version = doc.DocumentElement.SelectSingleNode("/Project/PropertyGroup/Version").InnerText;
var baseDir = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Env.ScriptPath));
var solution = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, "src/ColoredConsole.sln"));
var output = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, "artifacts/output"));
var tests = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, "artifacts/tests"));
var logs = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, "artifacts/logs"));
var packs = new[] { System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, "src/ColoredConsole")) };

// solution agnostic tasks
var bau = Require<Bau>();

bau
.Task("default").DependsOn("accept", "pack")

.Task("logs").Do(() => CreateDirectory(logs))

.Exec("clean").DependsOn("logs").Do(exec => exec
    .Run("dotnet").With("clean -v minimal -c Release ColoredConsole.sln /nologo /filelogger /fileloggerparameters:Summary;Verbosity:minimal;logfile=" + logs + "/clean.log").In("src"))

.Task("clobber").DependsOn("clean").Do(() => DeleteDirectory(output))

.Exec("restore").Do(exec => exec
    .Run("dotnet").With("restore ColoredConsole.sln").In("src"))

.Exec("build").DependsOn("clean", "restore", "logs").Do(exec => exec
    .Run("dotnet").With("build -v minimal --no-restore -c Release ColoredConsole.sln /nologo /FileLogger /fileloggerparameters:Summary;Verbosity:minimal;logfile=" + logs + "/build.log").In("src"))

.Task("tests").Do(() => CreateDirectory(tests))

.Exec("accept").DependsOn("build", "tests").Do(exec => exec
    .Run("dotnet").With($"xunit -nobuild -nologo -configuration Release -xml {tests}/acceptance.xml").In("src/test/ColoredConsole.Test.Acceptance"))

.Task("output").Do(() => CreateDirectory(output))

.Exec("pack").DependsOn("build", "clobber", "output").Do(exec =>
    {
        var versionText = version + versionSuffix;
        if (versionText.Length > 20)
        {
            versionText = versionText.Substring(0, 20);
        }
        foreach (var pack in packs)
        {
            bau.CurrentTask.LogInfo($"Packing '{pack}' into {output}...");
            exec.Run("dotnet").With($"pack --no-build -c Release /nologo -o {output} /p:PackageVersion={versionText}").In(pack);
        }
    })
.Run();

void CreateDirectory(string name)
{
    if (!Directory.Exists(name))
    {
        Directory.CreateDirectory(name);
        System.Threading.Thread.Sleep(100); // HACK (adamralph): wait for the directory to be created
    }
}

void DeleteDirectory(string name)
{
    if (Directory.Exists(name))
    {
        Directory.Delete(name, true);
    }
}
