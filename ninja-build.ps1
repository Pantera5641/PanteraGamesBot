Set-Location $PSScriptRoot

Remove-Item build -Recurse -Force 
mkdir build 
Set-Location build

cmake -G Ninja `
    -DCMAKE_C_COMPILER=clang-cl `
    -DCMAKE_CXX_COMPILER=clang-cl `
    -DCMAKE_BUILD_TYPE=Debug `
    -DCMAKE_EXPORT_COMPILE_COMMANDS=ON `
    ..
 
ninja

Set-Location ..