using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalWindow")]
    [OutputType(typeof(Window))]
    public sealed class NewTerminalWindowCommand : PSCmdlet
    {
        [Parameter(ValueFromPipeline = true)]
        [ValidateNotNull]
        public View? View { get; set; }

        [Parameter(Mandatory = true)]
        public string Title { get; set; } = string.Empty;

        [Parameter]
        public Pos X { get; set; } = 0;

        [Parameter]
        public Pos Y { get; set; } = 0;

        [Parameter]
        public Dim Width { get; set; } = Dim.Percent(100);

        [Parameter]
        public Dim Height { get; set; } = Dim.Percent(100);

        private Window? window;

        protected override void BeginProcessing()
        {
            this.window = new Window(this.Title)
            {
                X = this.X,
                Y = this.Y,
                Width = this.Width,
                Height = this.Height
            };
        }

        protected override void ProcessRecord()
        {
            if (this.View is null)
                return;
            this.window?.Add(this.View);
        }

        protected override void EndProcessing() => this.WriteObject(this.window);
    }
}