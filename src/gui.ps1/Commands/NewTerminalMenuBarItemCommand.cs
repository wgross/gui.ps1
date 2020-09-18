using System.Collections.Generic;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalMenuBarItem")]
    [OutputType(typeof(MenuBarItem))]
    public sealed class NewTerminalMenuBarItemCommand : NewTerminalCommandBase
    {
        [Parameter(Mandatory = true)]
        public string Title { get; set; } = string.Empty;

        [Parameter(ValueFromPipeline = true)]
        [ValidateNotNull]
        public MenuItem? MenuItem { get; set; }

        private readonly List<MenuItem> menueItems = new List<MenuItem>();

        protected override void BeginProcessing() => base.BeginProcessing();

        protected override void ProcessRecord()
        {
            if (this.MenuItem is { })
                this.menueItems.Add(this.MenuItem);
        }

        protected override void EndProcessing() => this.WriteObject(new MenuBarItem(this.Title, this.menueItems.ToArray()));
    }
}