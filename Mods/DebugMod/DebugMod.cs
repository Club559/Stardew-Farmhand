using Farmhand;
using Farmhand.Events;
using StardewValley;
using Microsoft.Xna.Framework.Input;
using System;
using StardewValley.Menus;
using DebugMod.Menus;
using System.ComponentModel;
using Farmhand.Helpers;

namespace DebugMod
{
    public class DebugMod : Mod
    {
        public static event EventHandler<DebugEventArgs> OnDebugInput = delegate { };

        public override void Entry()
        {
            ControlEvents.OnKeyPressed += ControlEvents_OnKeyPressed;
        }

        private void ControlEvents_OnKeyPressed(object sender, Farmhand.Events.Arguments.ControlEvents.EventArgsKeyPressed e)
        {
            if (e.KeyPressed == Keys.F3 && Game1.activeClickableMenu == null)
            {
                Game1.activeClickableMenu = new DebugMenu(new NamingMenu.doneNamingBehavior(processDebugInput));
            }
        }

        private void processDebugInput(string input)
        {
            Game1.exitActiveMenu();
            DebugMenu.lastDebugInput = input;

            string newInput = input.Trim();
            if (newInput == "")
                return;

            DebugEventArgs args = new DebugEventArgs(newInput);
            EventCommon.SafeCancellableInvoke(OnDebugInput, null, args);

            if (!args.Cancel)
                Game1.game1.parseDebugInput(newInput);
        }
    }

    public class DebugEventArgs : CancelEventArgs
    {
        public DebugEventArgs(string input)
        {
            Input = input;
            Args = input.Split(' ');
        }

        public string Input { get; private set; }
        public string[] Args { get; private set; }
    }
}
