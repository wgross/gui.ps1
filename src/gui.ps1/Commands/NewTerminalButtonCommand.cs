using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalButton")]
    [OutputType(typeof(Button))]
    public sealed class NewTerminalButtonCommand : NewTerminalViewCommandBase
    {
        [Parameter(Mandatory = true)]
        public string Text { get; set; } = string.Empty;

        [Parameter()]
        public SwitchParameter IsDefault { get; set; }

        [Parameter]
        [ValidateRange(0, int.MaxValue)]
        public int X { get; set; } = 0;

        [Parameter]
        [ValidateRange(0, int.MaxValue)]
        public int Y { get; set; } = 0;

        [Parameter()]
        public ScriptBlock Clicked { get; set; } = ScriptBlock.Create(string.Empty);

        protected override void BeginProcessing() => base.BeginProcessing();

        protected override void ProcessRecord()
        {
            var button = new Button(this.X, this.Y, this.Text, this.IsDefault.ToBool());
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Clicked)))
                button.Clicked = () => this.Clicked.InvokeReturnAsIs();
            this.WriteObject(button);
        }
    }
}