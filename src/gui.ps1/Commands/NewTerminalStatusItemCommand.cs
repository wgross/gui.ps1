using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalStatusItem")]
    [OutputType(typeof(StatusItem))]
    public sealed class NewTerminalStatusItemCommand : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public Key Key { get; set; }

        [Parameter(Mandatory = true)]
        public string Title { get; set; } = string.Empty;

        [Parameter]
        [ValidateNotNull]
        public ScriptBlock Action { get; set; } = ScriptBlock.Create(string.Empty);

        protected override void ProcessRecord() => this.WriteObject(new StatusItem(this.Key, this.Title, () => this.Action.InvokeReturnAsIs()));
    }
}