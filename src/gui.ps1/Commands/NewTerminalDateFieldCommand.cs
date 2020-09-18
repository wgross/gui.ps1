using System;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalDateField")]
    [OutputType(typeof(DateField))]
    public sealed class NewTerminalDateFieldCommand : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public DateTime Date { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateRange(0, int.MaxValue)]
        public int X { get; set; } = 0;

        [Parameter(Mandatory = true)]
        [ValidateRange(0, int.MaxValue)]
        public int Y { get; set; } = 0;

        [Parameter()]
        public SwitchParameter IsShort { get; set; }

        protected override void ProcessRecord() => this.WriteObject(new DateField(this.X, this.Y, this.Date, this.IsShort));
    }
}