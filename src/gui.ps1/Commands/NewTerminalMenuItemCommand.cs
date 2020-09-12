using System;
using System.Management.Automation;
using Terminal.Gui;

namespace gui.ps1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalMenuItem")]
    [CmdletBinding(DefaultParameterSetName = "withAction")]
    [OutputType(typeof(MenuItem))]
    public sealed class NewTerminalMenuItemCommand : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Title { get; set; } = string.Empty;

        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        public string Help { get; set; } = string.Empty;

        [Parameter(Mandatory = true, ParameterSetName = "withAction")]
        public Action Action { get; set; } = delegate { };

        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        public Func<bool> CanExecute { get; set; } = () => true;

        [Parameter(ParameterSetName = "quit")]
        public SwitchParameter Quit { get; set; }

        protected override void EndProcessing()
        {
            switch (ParameterSetName)
            {
                case "quit":
                    this.WriteObject(new MenuItem(this.Title, this.Help, action: () => Application.RequestStop(), canExecute: this.CanExecute));
                    break;

                default:
                    this.WriteObject(new MenuItem(this.Title, this.Help, action: this.Action, canExecute: this.CanExecute));
                    break;
            }
        }
    }
}