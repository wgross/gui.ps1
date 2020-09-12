using System.Collections.Generic;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsLifecycle.Start, "TerminalApplication")]
    public class StartTerminalApplicationCommand : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public View? View { get; set; }

        private readonly List<View> views = new List<View>();

        protected override void BeginProcessing()
        {
            Application.Init();
        }

        protected override void ProcessRecord()
        {
            if (this.View is { })
                this.views.Add(this.View);
        }

        protected override void EndProcessing()
        {
            Application.Top.Add(this.views.ToArray());
            Application.Run();
            Application.Shutdown();
        }

        private void AddMenu()
        {
            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_Quit", "", () => { Application.RequestStop(); })
                })
            });
            this.views.Add(menu);
        }

        //private void AddWindow()
        //{
        //    var win = new Window("MyApp")
        //    {
        //        X = 0,
        //        Y = 1, // Leave one row for the toplevel menu

        //        // By using Dim.Fill(), it will automatically resize without manual intervention
        //        Width = Dim.Fill(),
        //        Height = Dim.Fill()
        //    };
        //    this.views.Add(win);
        //}
    }
}