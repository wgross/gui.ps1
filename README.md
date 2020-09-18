# gui.ps1
PowerShell cmdlet wrapper for Miguel De Icazas gui.cs

This is far from being complete. I consider this more a spike of how a powershell integration of gui.cs could look like.

The goal was to create a gui with a powershell script in a "powershelly" way. 
This means:
- Controls are created by powershell commands: 
```powershell
New-TerminalButton, New-TerminalWindow,...
```
- Properties and event handlers can be set at creation time of the control using arguments: 
```powershell
New-TerminalButton -Text "Quit" -IsDefault -X 3 -Y 3
```
- Event Handler are supplied as script blocks: 
```powershell 
New-TerminalButton -Text "Quit" -Clicked { [Application]::RequestStop() }
```
- Controls receive the child views from the pipe: 
```powershell
New-TerminalLabel -Text  "This is a Label" -X 3 -Y 1 | New-TerminalWindow -Title "test"
```
At least the simple cases (see: test.ui.ps1 in projects root) are working but not all properties of the controls or the event handlers are yet accessible by the cmdlets.
Also more complex scenarios like scrollviewer I have not explored yet. 

# Using the project

Just clone the repo to your machine. The test.ps1 in the root compiles, publishes and loads the module in the current powershell instance. 
It also calls the test.ui.ps1 which contains the actual UI-building code.

If you have any feedback, let me know :-)




