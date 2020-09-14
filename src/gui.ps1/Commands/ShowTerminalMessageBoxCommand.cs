using System.Linq;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.Show, "TerminalMessageBox")]
    [OutputType(typeof(int))]
    public sealed class ShowTerminalMessageBoxCommand : ShowTerminalBoxCommandBase
    {
        protected override int ShowBox(int width, int height, string title, string message, string[]? button)
            => MessageBox.Query(this.Height, this.Width, this.Title, this.Message, this.Buttons?.Select(b => (NStack.ustring)b).ToArray());
    }
}