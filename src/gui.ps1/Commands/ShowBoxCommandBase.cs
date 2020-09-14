using System.Management.Automation;

namespace GuiPs1.Commands
{
    public abstract class ShowBoxCommandBase : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Message { get; set; } = string.Empty;

        [Parameter(Mandatory = true)]
        [ValidateNotNull] // gui.cs throws on null button array; also doesnt make much sense to have no buttons
        public string[]? Buttons { get; set; }

        [Parameter]
        public string Title { get; set; } = string.Empty;

        [Parameter]
        public int Height { get; set; } = 0;

        [Parameter]
        public int Width { get; set; } = 0;

        protected override void ProcessRecord() => this.WriteObject(this.ShowBox(this.Width, this.Height, this.Title, this.Message, this.Buttons));

        protected abstract int ShowBox(int width, int height, string title, string message, string[]? button);
    }
}