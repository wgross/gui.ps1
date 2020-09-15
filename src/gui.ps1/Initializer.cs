using System.Management.Automation;
using Terminal.Gui;

namespace gui.ps1
{
    public sealed class MyModuleAssemblyInitializer : IModuleAssemblyInitializer
    {
        public void OnImport() => Application.Init();
    }
}