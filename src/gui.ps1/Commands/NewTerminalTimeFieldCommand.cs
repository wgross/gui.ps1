using System;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalTimeField", DefaultParameterSetName = nameof(ViewPlacementParameterSets.Computed))]
    [OutputType(typeof(TimeField))]
    public sealed class NewTerminalTimeFieldCommand : NewTerminalTextFieldCommandBase<TimeField>
    {
        [Parameter(Mandatory = true)]
        public TimeSpan Time { get; set; }

        [Parameter()]
        public SwitchParameter IsShortFormat { get; set; }

        [Parameter()]
        public ScriptBlock TimeChanged { get; set; } = ScriptBlock.Create(string.Empty);

        protected override void ProcessRecord()
        {
            var timeField = this.SetTextChanged(this.View());

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(TimeChanged)))
                timeField.TimeChanged = ev => this.TimeChanged.InvokeReturnAsIs(ev);

            this.WriteObject(timeField);
        }

        protected override TimeField View()
        {
            return this.ParameterSetName switch
            {
                nameof(ViewPlacementParameterSets.Absolute) => new TimeField(this.X, this.Y, this.Time, this.IsShortFormat),

                _ => new TimeField(this.Time) { IsShortFormat = this.IsShortFormat }
            };
        }
    }
}