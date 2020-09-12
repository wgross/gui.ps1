using namespace Terminal.Gui
using namespace System

"$PSScriptRoot\src\gui.ps1\"|Push-Location
try {
    dotnet publish
} finally {
    Pop-Location
}

"$PSScriptRoot\src\gui.ps1\bin\Debug\netstandard2.1\publish"|Push-Location
try {
    Import-Module "./gui.ps1.dll"

    #New-TerminalMenuItem -Title "Q_uit" -Quit | New-TerminalMenuBarItem -Title "F_ile" | New-TerminalMenuBar | Start-TerminalApplication
    @(
        New-TerminalMenuItem -Title "Q_uit" -Action ([Action]{ [Application]::RequestStop() }) | New-TerminalMenuBarItem -Title "F_ile" | New-TerminalMenuBar 
        new-TerminalWindow -Title "test" -X 0 -Y 0
    ) | Start-TerminalApplication
    
} finally {
    Pop-Location
}

# see also:
# http://reza-aghaei.com/net-action-func-delegate-lambda-expression-in-powershell/
