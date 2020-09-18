using System.Collections.Generic;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalMenuBar")]
    [OutputType(typeof(MenuBar))]
    public sealed class NewTerminalMenuBarCommand : NewTerminalViewCommandBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public MenuBarItem? MenuBarItem { get; set; }

        private readonly List<MenuBarItem> menuBarItems = new List<MenuBarItem>();

        protected override void BeginProcessing() => base.BeginProcessing();

        protected override void ProcessRecord()
        {
            if (this.MenuBarItem is { })
                this.menuBarItems.Add(this.MenuBarItem);
        }

        protected override void EndProcessing() => this.WriteObject(new MenuBar(this.menuBarItems.ToArray()));
    }
}