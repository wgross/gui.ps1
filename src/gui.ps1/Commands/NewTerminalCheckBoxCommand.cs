using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalCheckBox", DefaultParameterSetName = nameof(ViewPlacementParameterSets.Computed))]
    [OutputType(typeof(CheckBox))]
    public sealed class NewTerminalCheckBoxCommand : NewTerminalPrimitiveViewCommandBase<CheckBox>
    {
        [Parameter(Mandatory = true)]
        public string Text { get; set; } = string.Empty;

        [Parameter]
        public SwitchParameter IsChecked { get; set; }

        [Parameter()]
        public ScriptBlock Toggled { get; set; } = ScriptBlock.Create(string.Empty);

        protected override void ProcessRecord()
        {
            var checkbox = this.View();
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Toggled)))
                checkbox.Toggled = b => this.Toggled.InvokeReturnAsIs(b);
            this.WriteObject(checkbox);
        }

        protected override CheckBox View()
        {
            return this.ParameterSetName switch
            {
                nameof(ViewPlacementParameterSets.Absolute) => new CheckBox(this.X, this.Y, this.Text, this.IsChecked.ToBool()),

                _ => new CheckBox(this.Text, this.IsChecked.IsPresent)
            };
        }
    }
}