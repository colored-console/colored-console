# How to build

These instructions are *only* for building with Bau, including compilation, tests and packaging. This is the simplest way to build.

You can also build with Visual Studio 2017 or later or with the .NET CLI.

*Don't be put off by the prerequisites!* It only takes a few minutes to set them up and only needs to be done once. If you haven't used Bau before then you're in for a real treat!

If you used the build scrits, after the build has completed, the build artifacts will be located in `artifacts`.

## Windows

1. Ensure you have .NET Core installed.

1. Ensure you have [scriptcs 0.13.3 or later](http://chocolatey.org/packages/ScriptCs) installed.

1. Using a command prompt, navigate to your clone root folder and execute:

    `build.bat`

## Linux

1. Ensure you have Mono development tools 3.0 or later installed.

    `sudo apt install mono-devel`

1. Ensure your mono instance has root SSL certificates

    `mozroots --import --sync`

1. Using a terminal, navigate to your clone root folder and execute:

    `bash build.sh`

## .NET CLI

* Build with `dotnet build`. You can build the .sln or the projects directly.
* Test with `dotnet test` or `dotnet xunit` in the test directory.
* Package with `dotnet pack` in the main project directory.

## Docker

1. Build the image.

    `docker build -t colorfulconsole .`.

1. Run the container (this commands work both on Linux and Windows/PowerShell).

    `docker run -ti --name coloredconsole -v "$(pwd):/app" coloredconsole`

After you exit the container you can come back to it by running `docker start -ai colorfulconsole`.
You can use `build.sh` or the .NET CLI to build.
