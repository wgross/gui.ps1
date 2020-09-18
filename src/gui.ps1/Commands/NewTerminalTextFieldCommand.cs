using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalTextField")]
    [OutputType(typeof(TextField))]
    public sealed class NewTerminalTextFieldCommand : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Text { get; set; } = string.Empty;

        [Parameter(Mandatory = true)]
        [ValidateRange(0, int.MaxValue)]
        public int X { get; set; } = 0;

        [Parameter(Mandatory = true)]
        [ValidateRange(0, int.MaxValue)]
        public int Y { get; set; } = 0;

        [Parameter(Mandatory = true)]
        [ValidateRange(0, int.MaxValue)]
        public int Width { get; set; } = 0;

        protected override void ProcessRecord() => this.WriteObject(new TextField(this.X, this.Y, this.Width, this.Text));
    }
}