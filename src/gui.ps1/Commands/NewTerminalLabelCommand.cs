using NStack;
using System.Management.Automation;
using Terminal.Gui;

namespace gui.ps1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalLabel")]
    public sealed class NewTerminalLabelCommand : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public ustring Text { get; private set; } = string.Empty;

        [Parameter]
        [ValidateRange(0, int.MaxValue)]
        public int X { get; set; } = 0;

        [Parameter]
        [ValidateRange(0, int.MaxValue)]
        public int Y { get; set; } = 0;

        protected override void ProcessRecord() => this.WriteObject(new Label(this.X, this.Y, this.Text));
    }
}