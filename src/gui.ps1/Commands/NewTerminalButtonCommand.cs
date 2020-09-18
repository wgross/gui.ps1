using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalButton", DefaultParameterSetName = nameof(ViewPlacementParameterSets.Computed))]
    [OutputType(typeof(Button))]
    public sealed class NewTerminalButtonCommand : NewTerminalPrimitiveViewCommandBase<Button>
    {
        [Parameter(Mandatory = true)]
        public string Text { get; set; } = string.Empty;

        [Parameter()]
        public SwitchParameter IsDefault { get; set; }

        [Parameter()]
        public ScriptBlock Clicked { get; set; } = ScriptBlock.Create(string.Empty);

        protected override void ProcessRecord()
        {
            var button = this.View();
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Clicked)))
                button.Clicked = () => this.Clicked.InvokeReturnAsIs();
            this.WriteObject(button);
        }

        protected override Button View()
        {
            return this.ParameterSetName switch
            {
                nameof(ViewPlacementParameterSets.Absolute) => new Button(this.X, this.Y, this.Text, this.IsDefault.ToBool()),

                _ => new Button(this.Text, this.IsDefault.IsPresent)
            };
        }
    }
}