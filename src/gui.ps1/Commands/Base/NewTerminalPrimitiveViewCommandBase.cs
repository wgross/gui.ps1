using GuiPs1.Commands;
using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    public abstract class NewTerminalPrimitiveViewCommandBase<V> : NewTerminalCommandBase
        where V : View
    {
        [Parameter(ParameterSetName = nameof(ViewPlacementParameterSets.Absolute))]
        [ValidateRange(0, int.MaxValue)]
        public int X { get; set; } = 0;

        [Parameter(ParameterSetName = nameof(ViewPlacementParameterSets.Absolute))]
        [ValidateRange(0, int.MaxValue)]
        public int Y { get; set; } = 0;

        protected abstract V View();

        protected override void BeginProcessing() => base.BeginProcessing();
    }
}