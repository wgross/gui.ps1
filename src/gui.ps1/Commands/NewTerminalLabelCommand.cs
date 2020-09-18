using NStack;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalLabel", DefaultParameterSetName = nameof(ViewPlacementParameterSets.Computed))]
    [OutputType(typeof(Label))]
    public sealed class NewTerminalLabelCommand : NewTerminalPrimitiveViewCommandBase<Label>
    {
        [Parameter(Mandatory = true)]
        public ustring Text { get; private set; } = string.Empty;

        [Parameter()]
        public ScriptBlock Clicked { get; set; } = ScriptBlock.Create(string.Empty);

        protected override void ProcessRecord()
        {
            var label = this.View();

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Clicked)))
                label.Clicked = () => this.Clicked.InvokeReturnAsIs();

            this.WriteObject(label);
        }

        protected override Label View()
        {
            return this.ParameterSetName switch
            {
                nameof(ViewPlacementParameterSets.Absolute) => new Label(this.X, this.Y, this.Text),

                _ => new Label(this.Text)
            };
        }
    }
}