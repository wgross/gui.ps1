using System;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalTimeField")]
    [OutputType(typeof(TimeField))]
    public sealed class NewTerminalTimeFieldCommand : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public TimeSpan Time { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateRange(0, int.MaxValue)]
        public int X { get; set; } = 0;

        [Parameter(Mandatory = true)]
        [ValidateRange(0, int.MaxValue)]
        public int Y { get; set; } = 0;

        [Parameter()]
        public SwitchParameter IsShort { get; set; }

        protected override void ProcessRecord() => this.WriteObject(new TimeField(this.X, this.Y, this.Time, this.IsShort));
    }
}