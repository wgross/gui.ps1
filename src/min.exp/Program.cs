using System;
using Terminal.Gui;

Application.Init ();

var menu = new MenuBar (new MenuBarItem [] 
{
    new MenuBarItem ("_File", new MenuItem [] 
    {
        new MenuItem ("_Quit", "", () => { Application.RequestStop (); })
    })
});

Application.Top.Add (menu);
Application.Run ();
