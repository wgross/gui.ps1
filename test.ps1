"$PSScriptRoot\src\gui.ps1\"|Push-Location
try {
    dotnet publish
} finally {
    Pop-Location
}

"$PSScriptRoot\src\gui.ps1\bin\Debug\netstandard2.1\publish"|Push-Location
try {
    Import-Module "./gui.ps1.dll"    
} finally {
    Pop-Location
}

& $PSScriptRoot/test.ui.ps1

