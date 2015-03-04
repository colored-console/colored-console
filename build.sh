#!/usr/bin/env bash
set -e
set -o pipefail
set -x

# install
if [ ! -d ./scriptcs ]
  then
    rm -f ./ScriptCs.0.13.3.nupkg
    wget "http://chocolatey.org/api/v2/package/ScriptCs/0.13.3" -O ScriptCs.0.13.3.nupkg
    unzip ./ScriptCs.0.13.3.nupkg -d scriptcs
fi

mono ./scriptcs/tools/scriptcs.exe -install
if [ -d ./scriptcs_packages/Bau.XUnit.0.1.0-beta06 ]
  then
    mv ./scriptcs_packages/Bau.XUnit.0.1.0-beta06/Bau.XUnit.0.1.0-beta06.nupkg ./scriptcs_packages/Bau.XUnit.0.1.0-beta06/Bau.Xunit.0.1.0-beta06.nupkg
    mv ./scriptcs_packages/Bau.XUnit.0.1.0-beta06 ./scriptcs_packages/Bau.Xunit.0.1.0-beta06
fi
  
# script
mono ./scriptcs/tools/scriptcs.exe ./mono.csx -- $@
