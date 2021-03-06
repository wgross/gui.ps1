﻿using System.Management.Automation;
using Terminal.Gui;

namespace GuiPs1.Commands
{
    public enum ViewPlacementParameterSets
    {
        Computed,

        Absolute
    }

    public abstract class NewTerminalCommandBase : PSCmdlet
    {
        private static bool isInitialized = false;

        protected override void BeginProcessing() => this.EnsureApplicationInitialized();

        private void EnsureApplicationInitialized()
        {
            if (!isInitialized)
                Application.Init();
            isInitialized = true;
        }

        protected void Shutdown() => isInitialized = false;
    }
}