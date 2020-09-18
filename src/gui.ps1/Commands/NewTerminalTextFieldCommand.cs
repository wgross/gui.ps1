using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalTextField", DefaultParameterSetName = nameof(ViewPlacementParameterSets.Computed))]
    [OutputType(typeof(TextField))]
    public sealed class NewTerminalTextFieldCommand : NewTerminalTextFieldCommandBase<TextField>
    {
        [Parameter(Mandatory = true)]
        public string Text { get; set; } = string.Empty;

        [Parameter(Mandatory = true)]
        [ValidateRange(0, int.MaxValue)]
        public int Width { get; set; } = 0;

        protected override void ProcessRecord() => this.WriteObject(this.SetTextChanged(this.View()));

        protected override TextField View()
        {
            return this.ParameterSetName switch
            {
                nameof(ViewPlacementParameterSets.Absolute) => new TextField(this.X, this.Y, this.Width, this.Text),

                _ => new TextField(this.Text),
            };
        }
    }
}