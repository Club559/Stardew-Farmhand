using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using StardewValley.Menus;

namespace DebugMod.Menus
{
    public class DebugMenu : NamingMenu
    {
        public static string lastDebugInput = "";

        public DebugMenu(doneNamingBehavior b)
          : base(b, "Debug Input:", "")
        {
            this.textBox.limitWidth = false;
            this.textBox.Width = Game1.tileSize * 8;
            this.textBox.X -= Game1.tileSize * 2;
            this.randomButton.bounds.X += Game1.tileSize * 2;
            this.doneNamingButton.bounds.X += Game1.tileSize * 2;
            this.minLength = 0;
        }

        public override void update(GameTime time)
        {
            if (!Keyboard.GetState().IsKeyDown(Keys.Escape))
                return;
            Game1.exitActiveMenu();
            lastDebugInput = this.textBox.Text;
        }

        public override void receiveLeftClick(int x, int y, bool playSound = true)
        {
            if (this.randomButton.containsPoint(x, y))
            {
                this.textBox.Text = lastDebugInput;
                this.randomButton.scale = this.randomButton.baseScale;
                Game1.playSound("drumkit6");
            }
            else
                base.receiveLeftClick(x, y, playSound);
        }
    }
}
