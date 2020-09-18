using NStack;
using System.Linq;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalRadioGroup")]
    [OutputType(typeof(RadioGroup))]
    public sealed class NewTerminalRadioGroupCommand : NewTerminalViewCommandBase
    {
        [Parameter(Mandatory = true)]
        public string[] RadioLabels = new string[0];

        [Parameter]
        [ValidateRange(0, int.MaxValue)]
        public int X { get; set; } = 0;

        [Parameter]
        [ValidateRange(0, int.MaxValue)]
        public int Y { get; set; } = 0;

        protected override void BeginProcessing() => base.BeginProcessing();

        protected override void ProcessRecord() => this.WriteObject(new RadioGroup(this.X, this.Y, this.RadioLabels.Select(s => (ustring)s).ToArray()));
    }
}