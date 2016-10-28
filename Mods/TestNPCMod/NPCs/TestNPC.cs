using Farmhand.API.NPCs;
using Farmhand.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNPCMod.NPCs
{
    public class TestNPC : NPC
    {
        private static NPCInformation _information;
        public static NPCInformation Information => _information ?? (_information = new NPCInformation
        {
            Name = "Ashley",
            Spritesheet = TestNPCMod.Instance.ModSettings.GetTexture("spritesheet_Ashley"),
            Portrait = TestNPCMod.Instance.ModSettings.GetTexture("portrait_Ashley"),
            StartingMap = "WizardHouse",
            StartingX = 2,
            StartingY = 6,
            Facing = 3,
            Datable = false,
            Dispositions = new NPCDispositions(NPCAge.CHILD, NPCManners.RUDE, NPCSocialAnxiety.SHY, NPCOptimism.NEGATIVE, NPCGender.FEMALE, birthSeason: "spring", birthDay: 8),
            GiftTastes = "Thanks! I needed this!$h/64 336/Thanks. I could use this.$h/-28 420 257 281 107 305 247/What purpose do you expect this to serve for me?$s/80 348 346 303 -74/This is a waste of my time. I'm in the middle of something./390 388 330 571 568 569/Um... thanks?$u// ",
            Dialogue = new Dictionary<string, string>()
            {
                { "Introduction", "...Hello.$u#$e#I'm busy right now." },
                { "Mon", "Hey... do you want to see my demon?#$e#His name is Red.$h#$e#He's not here right now.$u" },
                { "Tue", "I'm working on a brew right now.$u#$e#It should turn you into a Venusaur." },
                { "Tue2", "I'm working on a brew right now.$u#$e#It should allow you to bark like a dog." },
                { "Tue4", "I'm working on a brew right now.$u#$e#It should show you the locations of rare ingredients." },
                { "Tue6", "I'm working on a brew right now.$u#$e#It should give you bat wings." },
                { "Tue8", "I'm working on a brew right now.$u#$e#It should increase your stamina immensely." },
                { "Tue10", "I'm working on a brew right now.$u#$e#It should enable you to cast spells." },
                { "Wed", "Have you ever made a deal with someone you don't know?#$e#Yeah, neither have I.$u#$e#Wanna make a deal?$h" },
                { "Wed4", "Life would be a lot easier if Red was around.$u#$e#Without his assistance, all I can do is make faulty potions.$s" },
                { "Wed8", "Think you could help me out with this brew?#$e#You'd make a great ingredient.$h#$e#Just kidding.$h" },
                { "Thu", "That wizard I live with makes me study his strange magic with him.$s#$e#He treats me like I'm his assistant.$a" },
                { "Thu4", "Even though the wizard treats me like a little kid, I'm fine with living here.$h#$e#I really want to go back, though.$s" },
                { "Thu8", "It's nice to have someone else visit me often.$h#$e#The wizard doesn't make great company.$u" },
                { "Fri", "I wonder where Red disappeared to.$s#$e#He's probably dead.$u#$e#If he's not, then he will be when I'm through with him.$a" },
                { "Fri6", "I've just accepted that I'm probably never going back.$u#$e#Your visits are making this place a bit more bearable, though.$h" },
                { "Sat", "You know, I could speed up your crop growth for you.#$e#I just need 2 eye of newt, 3 feet of troll, spit of dog, a horned goats tongue...$h#$b#What? You don't have any of those?$u" },
                { "Sat4", "One of these days, I'll get the right ingredients for my brew.$u#$e#When I do, I'll let you test it." },
                { "Sun", "Why do you insist on talking to me?$u#$e#I'm a little busy here.$u" },
                { "Sun4", "That brew I was working on turned out to be a failure, as usual.$s#$e#I'll just have to try again.$h" }
            },
            Schedule = new Dictionary<string, string>()
            {
                { "Mon", "1000 WizardHouse 4 13 0/1400 WizardHouse 4 19 2/1800 WizardHouse 2 6 3" },
                { "Tue", "1000 WizardHouse 11 6 1/1400 WizardHouse 4 19 2/1800 WizardHouse 2 6 3" },
                { "Wed", "1000 WizardHouse 8 5 0/1400 WizardHouse 4 19 2/1800 WizardHouse 2 6 3" },
                { "Thu", "1000 WizardHouse 10 15 2/1400 WizardHouse 4 19 2/1800 WizardHouse 2 6 3" },
                { "Fri", "1000 WizardHouse 5 5 0/1400 WizardHouse 4 19 2/1800 WizardHouse 2 6 3" },
                { "Sat", "1000 WizardHouse 1 20 1/1400 WizardHouse 4 19 2/1800 WizardHouse 2 6 3" },
                { "Sun", "1000 WizardHouse 9 20 2/1400 WizardHouse 4 19 2/1800 WizardHouse 2 6 3" }
            }
        });

        public TestNPC()
            :base()
        {

        }

        public TestNPC(AnimatedSprite sprite, Vector2 position, string defaultMap, int facingDir, string name, bool dateable, Dictionary<int, int[]> schedule, Texture2D portrait)
            : base(sprite, position, defaultMap, facingDir, name, dateable, schedule, portrait)
        {

        }

        public override void reloadSprite()
        {
            base.reloadSprite();
            this.sprite.spriteWidth = 24;
            this.sprite.spriteHeight = 32;
            this.faceDirection(this.defaultFacingDirection);
            this.sprite.standAndFaceDirection(this.defaultFacingDirection);
        }

        public override Rectangle GetBoundingBox()
        {
            if (this.sprite == null)
                return Rectangle.Empty;
            return new Rectangle((int)this.position.X + Game1.tileSize / 8, (int)this.position.Y + Game1.tileSize / 4, 16 * Game1.pixelZoom * 3 / 4, Game1.tileSize / 2);
        } 

        public override Rectangle getMugShotSourceRect()
        {
            return new Rectangle(1, 4, 22, 24);
        }
    }
}
