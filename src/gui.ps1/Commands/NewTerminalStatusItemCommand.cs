using System;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalStatusItem")]
    [OutputType(typeof(StatusItem))]
    public class NewTerminalStatusItemCommand : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public Key Key { get; set; }

        [Parameter(Mandatory = true)]
        public string Title { get; set; } = string.Empty;

        [Parameter]
        [ValidateNotNull]
        public Action Action { get; set; } = delegate { };

        protected override void ProcessRecord() => this.WriteObject(new StatusItem(this.Key, this.Title, this.Action));
    }
}