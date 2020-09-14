using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalCheckBox")]
    [OutputType(typeof(CheckBox))]
    public sealed class NewTerminalCheckBoxCommand : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Text { get; set; } = string.Empty;

        [Parameter]
        [ValidateRange(0, int.MaxValue)]
        public int X { get; set; } = 0;

        [Parameter]
        [ValidateRange(0, int.MaxValue)]
        public int Y { get; set; } = 0;

        [Parameter]
        public SwitchParameter IsChecked { get; set; }

        protected override void ProcessRecord() => this.WriteObject(new CheckBox(this.X, this.Y, this.Text, this.IsChecked.ToBool()));
    }
}