using System;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalDateField", DefaultParameterSetName = nameof(ViewPlacementParameterSets.Computed))]
    [OutputType(typeof(DateField))]
    public sealed class NewTerminalDateFieldCommand : NewTerminalTextFieldCommandBase<DateField>
    {
        [Parameter(Mandatory = true)]
        public DateTime Date { get; set; }

        [Parameter()]
        public SwitchParameter IsShortFormat { get; set; }

        [Parameter()]
        public ScriptBlock DateChanged { get; set; } = ScriptBlock.Create(string.Empty);

        protected override void ProcessRecord()
        {
            var dateField = this.SetTextChanged(this.View());

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(DateChanged)))
                dateField.DateChanged = ev => this.DateChanged.InvokeReturnAsIs(ev);

            this.WriteObject(dateField);
        }

        protected override DateField View()
        {
            return this.ParameterSetName switch
            {
                nameof(ViewPlacementParameterSets.Absolute) => new DateField(this.X, this.Y, this.Date, this.IsShortFormat),

                _ => new DateField(this.Date) { IsShortFormat = this.IsShortFormat }
            };
        }
    }
}