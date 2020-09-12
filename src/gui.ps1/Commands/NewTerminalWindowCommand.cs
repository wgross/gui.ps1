using System.Management.Automation;
using Terminal.Gui;

namespace gui.ps1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalWindow")]
    [OutputType(typeof(Window))]
    public class NewTerminalWindowCommand : PSCmdlet
    {
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

        protected override void EndProcessing()
        {
            this.WriteObject(new Window(this.Title)
            {
                X = this.X,
                Y = this.Y,
                Width = this.Width,
                Height = this.Height
            });
        }
    }
}