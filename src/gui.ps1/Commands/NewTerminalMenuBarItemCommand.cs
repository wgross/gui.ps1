using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalMenuBarItem")]
    public class NewTerminalMenuBarItemCommand : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Title { get; set; }

        protected override void EndProcessing()
        {
            this.WriteObject(new MenuBarItem(this.Title, new MenuBarItem[0]));
        }
    }
}