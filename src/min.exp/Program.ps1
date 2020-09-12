"d:\src\gui.ps1\src\gui.ps1\"|Push-Location
try {
    dotnet publish
} finally {
    Pop-Location
}

Import-Module "D:\src\gui.ps1\src\gui.cs\UICatalog\bin\Debug\netcoreapp3.1\NStack.dll"
Import-Module "D:\src\gui.ps1\src\gui.cs\UICatalog\bin\Debug\netcoreapp3.1\Terminal.Gui.dll"
Import-Module "d:\src\gui.ps1\src\gui.ps1\bin\Debug\netstandard2.1\publish\gui.ps1.dll"

# $menu = [Terminal.Gui.MenuBar]::new([Terminal.Gui.MenuBarItem[]]@(
#     [Terminal.Gui.MenuBarItem]::new("File",[Terminal.Gui.MenuBarItem[]]@(
#         [Terminal.Gui.MenuItem]::new("_Quit", "", $null)
#     ))
# ))
#$menu|gm

$code= @{}
$code.ReferencedAssemblies = @(
    "netstandard"
    "D:\src\gui.ps1\src\gui.cs\UICatalog\bin\Debug\netcoreapp3.1\NStack.dll"
    "D:\src\gui.ps1\src\gui.cs\UICatalog\bin\Debug\netcoreapp3.1\Terminal.Gui.dll"
    )

$code.TypeDefinition = @"
using System;
using Terminal.Gui;

public class Program 
{
    public static MenuBar Run()
    {
        //Application.Init ();

        return  new MenuBar (new MenuBarItem [] 
        {
            new MenuBarItem ("_File", new MenuItem [] 
            {
                new MenuItem ("_Quit", "", () => { Application.RequestStop (); })
            })
        });

        //Application.Top.Add (menu);
        //Application.Run ();
    }
}
"@

#[Terminal.Gui.Application]::Init()

$global:type = Add-Type -Language CSharp @code
$menu = [Program]::Run()

$menu|Start-TerminalApplication

#[Terminal.Gui.Application]::Top.Add($menu);
#[Terminal.Gui.Application]::Run()
#[Terminal.Gui.Application]::Shutdown();
