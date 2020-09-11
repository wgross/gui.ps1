using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsLifecycle.Start, "TerminalApplication")]
    public class StartTerminalApplicationCommand : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public View View { get; set; }

        protected override void BeginProcessing()
        {
            Application.Init();
        }

        protected override void ProcessRecord()
        {
            Application.Top.Add(this.View);
        }

        protected override void EndProcessing()
        {
            Application.Run();
        }
    }
}