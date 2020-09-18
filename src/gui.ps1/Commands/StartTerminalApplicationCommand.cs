using System.Collections.Generic;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsLifecycle.Start, "TerminalApplication")]
    public class StartTerminalApplicationCommand : NewTerminalViewCommandBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public View? View { get; set; }

        private readonly List<View> views = new List<View>();

        protected override void BeginProcessing() => base.BeginProcessing();

        protected override void ProcessRecord()
        {
            if (this.View is { })
                this.views.Add(this.View);
        }

        protected override void EndProcessing()
        {
            try
            {
                Application.Top.Add(this.views.ToArray());
                Application.Run();
                Application.Shutdown();
            }
            finally
            {
                this.Shutdown();
            }
        }
    }
}