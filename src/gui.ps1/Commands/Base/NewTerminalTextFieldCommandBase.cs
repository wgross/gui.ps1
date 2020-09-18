using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    public abstract class NewTerminalTextFieldCommandBase<V> : NewTerminalPrimitiveViewCommandBase<V>
         where V : TextField
    {
      

        [Parameter()]
        public ScriptBlock TextChanged { get; set; } = ScriptBlock.Create(string.Empty);

        protected V SetTextChanged(V textField)
        {
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(TextChanged)))
                textField.TextChanged = ev => this.TextChanged.InvokeReturnAsIs(ev);
            return textField;
        }
    }
}