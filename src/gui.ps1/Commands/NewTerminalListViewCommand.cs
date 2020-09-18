using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.New, "TerminalListView")]
    [OutputType(typeof(ListView))]
    public sealed class NewTerminalListViewCommand : NewTerminalCommandBase
    {
        [Parameter(Mandatory = true)]
        public object[] Source { get; set; } = new object[0];

        [Parameter(Mandatory = true)]
        [ValidateRange(0, int.MaxValue)]
        public int X { get; set; } = 0;

        [Parameter(Mandatory = true)]
        [ValidateRange(0, int.MaxValue)]
        public int Y { get; set; } = 0;

        [Parameter(Mandatory = true)]
        [ValidateRange(0, int.MaxValue)]
        public int Width { get; set; } = 0;

        [Parameter(Mandatory = true)]
        [ValidateRange(0, int.MaxValue)]
        public int Height { get; set; } = 0;

        private Rect Rect() => new Rect(this.X, this.Y, this.Width, this.Height);

        protected override void BeginProcessing() => base.BeginProcessing();

        protected override void ProcessRecord() => this.WriteObject(new ListView(this.Rect(), this.Source));
    }
}