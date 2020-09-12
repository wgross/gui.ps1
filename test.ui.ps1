using namespace Terminal.Gui
using namespace System

#New-TerminalMenuItem -Title "Q_uit" -Quit | New-TerminalMenuBarItem -Title "F_ile" | New-TerminalMenuBar | Start-TerminalApplication

@(
    New-TerminalMenuItem -Title "Q_uit" -Action ([Action]{ [Application]::RequestStop() }) | New-TerminalMenuBarItem -Title "F_ile" | New-TerminalMenuBar 
    New-TerminalWindow -Title "test" -X 0 -Y 0
    New-TerminalStatusItem -Key "ControlQ" -Title "~^Q~ Quit" -Action ([Action]{ [Application]::RequestStop() }) | New-TerminalStatusBar
) | Start-TerminalApplication

# see also:
# http://reza-aghaei.com/net-action-func-delegate-lambda-expression-in-powershell/
