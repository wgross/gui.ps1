using namespace Terminal.Gui
using namespace System

#New-TerminalMenuItem -Title "Q_uit" -Quit | New-TerminalMenuBarItem -Title "F_ile" | New-TerminalMenuBar | Start-TerminalApplication

# declare som event handlers for reuse
$quit_action = { [Application]::RequestStop() }

$show_message_box = { 
    $result = Show-TerminalMessageBox -Height 10 -Width 30 -Message "choose a button" -Title "title" -Buttons "A","B","C"
    Show-TerminalErrorBox -Message "you chose button no $result" -Title "title" -Buttons "OK"
}

$field_changed = { param($change) Show-TerminalMessageBox -Height 10 -Width 30 -Message "field view changed: $($change.GetType())" -Title "Change" -Buttons "OK" }

$clicked = { 
    # not working with Label ... Label waits for Clicked but gets Pressed
    Show-TerminalMessageBox -Height 10 -Width 30 -Message "view clicked" -Title "Clicked" -Buttons "OK" 
}

# create the application with menue and statusbar
@(
    # build the menu
    New-TerminalMenuItem -Title "Q_uit" -Action $quit_action | New-TerminalMenuBarItem -Title "F_ile" | New-TerminalMenuBar 
    # and a status bar
    New-TerminalStatusItem -Key "ControlQ" -Title "~^Q~ Quit" -Action $quit_action | New-TerminalStatusBar
    # add main window
    @(
        # first a label 
        New-TerminalLabel -Text  "This is a Label" -X 3 -Y 1
        # then a button
        New-TerminalButton -Text "Quit" -IsDefault -Clicked $quit_action -X 3 -Y 3 
        # this button shows a message box
        New-TerminalButton -Text "Messagebox" -Clicked $show_message_box -X 3 -Y 5 
        # a checkbox
        New-TerminalCheckBox -Text "Checkbox" -X 3 -Y 7
        # a radio group with two label
        New-TerminalRadioGroup -X 3 -Y 9 -RadioLabels "one","two"
        # a combobox dislaying an array of objects
        New-TerminalComboBox -X 3 -Y 12 -Width 10 -Height 10 -Source "test",1
        # a text fields dislaying a defualt text
        New-TerminalTextField -X 3 -Y 14 -Width 10 -Text "default" -TextChanged $field_changed
        # a text fields dislaying a given datetime
        New-TerminalDateField -X 3 -Y 16 -Date (Get-Date) -IsShortFormat -DateChanged $field_changed
        # a text fields dislaying a given datetime
        New-TerminalTimeField -X 3 -Y 18 -Time ([TimeSpan]::FromHours(12)) -IsShortFormat -TimeChanged $field_changed

        # listview displaying a mixed list of objects
        New-TerminalListView -X 20 -Y 1 -Width 10 -Height 10 -Source "test",1,(Get-Date),"a","b","c"
        # Draw a frame 
        New-TerminalFrameView -X 20 -Y 10 -Width 15 -Height 10 -Title "Frameview"

    ) | New-TerminalWindow -Title "test" -X 0 -Y 0

) | Start-TerminalApplication

# see also:
# http://reza-aghaei.com/net-action-func-delegate-lambda-expression-in-powershell/
