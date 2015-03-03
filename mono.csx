Require<Bau>()

.Task("default").DependsOn("unit", "component", "accept")

.Task("logs").Do(() => CreateDirectory("./artifacts/logs"))

.Exec("clean").DependsOn("logs").Do(exec => exec
    .Run("xbuild")
    .With("./src/ColoredConsole.sln", "/target:Clean", "/property:Configuration=Release", "/verbosity:normal", "/nologo"))

.Exec("restore").Do(exec => exec
    .Run("mono")
    .With("./scriptcs_packages/NuGet.CommandLine.2.8.2/tools/NuGet.exe", "restore", "src/ColoredConsole.sln"))

.Exec("build").DependsOn("clean", "restore", "logs").Do(exec => exec
    .Run("xbuild")
    .With("./src/ColoredConsole.sln", "/target:Build", "/property:Configuration=Release", "/verbosity:normal", "/nologo"))

.Task("tests").Do(() => CreateDirectory("./artifacts/tests"))

.Xunit("unit").DependsOn("build", "tests").Do(xunit => xunit
    .Use("./scriptcs_packages/xunit.runners.1.9.2/tools/xunit.console.clr4.exe")
    .Run("./src/test/ColoredConsole.Test.Unit/bin/Release/ColoredConsole.Test.Unit.dll")
    .Html().Xml())

.Xunit("component").DependsOn("build", "tests").Do(xunit => xunit
    .Use("./scriptcs_packages/xunit.runners.1.9.2/tools/xunit.console.clr4.exe")
    .Run("./src/test/ColoredConsole.Test.Component/bin/Release/ColoredConsole.Test.Component.dll")
    .Html().Xml())

.Xunit("accept").DependsOn("build", "tests").Do(xunit => xunit
    .Use("./scriptcs_packages/xunit.runners.1.9.2/tools/xunit.console.clr4.exe")
    .Run("./src/test/ColoredConsole.Test.Acceptance/bin/Release/ColoredConsole.Test.Acceptance.dll")
    .Html().Xml())

.Run();

void CreateDirectory(string name)
{
    if (!Directory.Exists(name))
    {
        Directory.CreateDirectory(name);
        System.Threading.Thread.Sleep(100); // HACK (adamralph): wait for the directory to be created
    }
}
