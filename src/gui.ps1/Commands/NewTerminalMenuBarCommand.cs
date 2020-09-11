using System.Collections.Generic;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalMenuBar")]
    public class NewTerminalMenuBarCommand : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public MenuBarItem MenuBarItem { get; set; }

        private List<MenuBarItem> menuBarItems = new List<MenuBarItem>();

        protected override void ProcessRecord()
        {
            this.menuBarItems.Add(this.MenuBarItem);
        }

        protected override void EndProcessing()
        {
            this.WriteObject(new MenuBar(this.menuBarItems.ToArray()));
        }
    }
}