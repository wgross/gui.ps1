using NStack;
using System.Linq;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    [Cmdlet(VerbsCommon.Show, "TerminalErrorBox")]
    [OutputType(typeof(int))]
    public sealed class ShowTerminalErrorBoxCommand : ShowTerminalBoxCommandBase
    {
        protected override int ShowBox(int width, int height, string title, string message, string[]? button) 
            => MessageBox.ErrorQuery(this.Height, this.Width, this.Title, this.Message, this.Buttons?.Select(b => (ustring)b).ToArray());
    }
}