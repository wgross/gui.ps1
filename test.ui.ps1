using namespace Terminal.Gui
using namespace System

#New-TerminalMenuItem -Title "Q_uit" -Quit | New-TerminalMenuBarItem -Title "F_ile" | New-TerminalMenuBar | Start-TerminalApplication

# declare som evenet handlers for reuse
$quit_action = ([Action]{ [Application]::RequestStop() })

# create the application with mane and statusbar
@(
    # build th menu
    New-TerminalMenuItem -Title "Q_uit" -Action $quit_action | New-TerminalMenuBarItem -Title "F_ile" | New-TerminalMenuBar 
    # and a status bar
    New-TerminalStatusItem -Key "ControlQ" -Title "~^Q~ Quit" -Action $quit_action | New-TerminalStatusBar
    # add main window
    @(
        # first a label 
        New-TerminalLabel -Text  "This is a Label" -X 3 -Y 1
        # then a button
        New-TerminalButton -Text "Quit" -IsDefault -Clicked $quit_action -X 3 -Y 3 
    ) | New-TerminalWindow -Title "test" -X 0 -Y 0

) | Start-TerminalApplication

# see also:
# http://reza-aghaei.com/net-action-func-delegate-lambda-expression-in-powershell/
