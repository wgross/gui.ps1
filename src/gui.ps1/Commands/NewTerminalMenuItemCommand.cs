using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalMenuItem")]
    [CmdletBinding(DefaultParameterSetName = "withAction")]
    [OutputType(typeof(MenuItem))]
    public sealed class NewTerminalMenuItemCommand : NewTerminalViewCommandBase
    {
        [Parameter(Mandatory = true)]
        public string Title { get; set; } = string.Empty;

        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        public string Help { get; set; } = string.Empty;

        [Parameter(Mandatory = true, ParameterSetName = "withAction")]
        public ScriptBlock Action { get; set; } = ScriptBlock.Create(string.Empty);

        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        public ScriptBlock CanExecute { get; set; } = ScriptBlock.Create("$true");

        [Parameter(ParameterSetName = "quit")]
        public SwitchParameter Quit { get; set; }

        protected override void BeginProcessing() => base.BeginProcessing();

        protected override void EndProcessing()
        {
            switch (ParameterSetName)
            {
                case "quit":
                    this.WriteObject(new MenuItem(this.Title, this.Help, action: () => Application.RequestStop(), canExecute: () => this.AsBoolean(this.CanExecute.InvokeReturnAsIs())));
                    break;

                default:
                    this.WriteObject(new MenuItem(this.Title, this.Help, action: () => this.Action.InvokeReturnAsIs(), canExecute: () => this.AsBoolean(this.CanExecute.InvokeReturnAsIs())));
                    break;
            }
        }

        private bool AsBoolean(object obj) => obj switch
        {
            PSObject pso => AsBoolean(pso),
            _ => false
        };

        private bool AsBoolean(PSObject pso)
        {
            if (pso.BaseObject is bool b)
                return b;
            else return false;
        }
    }
}