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
            // this is hacky. Most likely i have to garantee that 
            // Init is called in the first BeginProcessing for all commands run after the last shutdown once
            // maybe using a static flag in a cmdlet base class for this?
            Application.Init();
        }
    }
}