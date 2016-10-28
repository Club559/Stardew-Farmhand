using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmhand.API.NPCs
{
    public class NPCInformation
    {
        //Mod that owns this NPC
        public Mod Owner { get; set; }

        //Name of the NPC
        public string Name { get; set; }

        //Texture of the NPC
        public Texture2D Spritesheet { get; set; }

        //Portrait of the NPC
        public Texture2D Portrait { get; set; }

        //Size of the sprite for each frame
        public int Width { get; set; } = 16;
        public int Height { get; set; } = 32;

        //Map the NPC starts in
        public string StartingMap { get; set; }

        //Location the NPC starts at
        public int StartingX { get; set; }
        public int StartingY { get; set; }
        public int Facing { get; set; } = 0;

        //Whether or not the NPC is datable
        public bool Datable { get; set; } = false;

        //More NPC info
        public NPCDispositions Dispositions { get; set; }

        //NPC dialogue
        public Dictionary<string, string> Dialogue { get; set; } = new Dictionary<string, string>();

        //NPC schedule
        public Dictionary<string, string> Schedule { get; set; } = new Dictionary<string, string>();

        //Gift tastes
        public string GiftTastes { get; set; }

        /// <summary>
        /// Type of the class to initialize for creating the NPC (Must extend StardewValley.NPC)
        /// </summary>
        public Type ClassType { get; set; } = typeof(NPC);

        /// <summary>
        /// Provides the API with basic info for a custom NPC.
        /// </summary>
        public NPCInformation() { }

        /// <summary>
        /// Provides the API with basic info for a custom NPC.
        /// </summary>
        /// <param name="owner">The mod registering this NPC</param>
        /// <param name="name">Name of the NPC</param>
        /// <param name="texture">Texture2D of the NPC spritesheet</param>
        /// <param name="startingMap">Name of the map the NPC will start in</param>
        /// <param name="startingX">X position of the NPC's spawn tile</param>
        /// <param name="startingY">Y position of the NPC's spawn tile</param>
        /// <param name="datable">True for datable, False for non-datable</param>
        /// <param name="dispositions">Contains more info on the NPC such as gender and birthday</param>
        public NPCInformation(string name, Texture2D spritesheet, Texture2D portrait, string startingMap, int startingX, int startingY, bool datable, int facing = 0, NPCDispositions dispositions = null)
        {
            this.Name = name;
            this.Spritesheet = spritesheet;
            this.Portrait = portrait;
            this.StartingMap = startingMap;
            this.StartingX = startingX;
            this.StartingY = startingY;
            this.Facing = facing;
            this.Datable = datable;
            this.Dispositions = dispositions;
        }

        public void AddDialogue(string id, string text)
        {
            this.Dialogue.Add(id, text);
        }

        public void AddSchedule(string id, string commands)
        {
            this.Schedule.Add(id, commands);
        }
    }

    public class NPCDispositions
    {
        public int Age { get; set; }
        public int Manners { get; set; }
        public int SocialAnxiety { get; set; }
        public int Optimism { get; set; }
        public int Gender { get; set; }
        public int HomeRegion { get; set; }
        public string LoveInterest { get; set; }
        public string BirthSeason { get; set; }
        public int BirthDay { get; set; }

        public NPCDispositions(
            int age = NPCAge.ADULT, 
            int manners = NPCManners.NEUTRAL,
            int socialAnxiety = NPCSocialAnxiety.NEUTRAL,
            int optimism = NPCOptimism.NEUTRAL,
            int gender = NPCGender.UNDEFINED,
            int homeRegion = NPCHomeRegion.OTHER,
            string loveInterest = "null",
            string birthSeason = null,
            int birthDay = 1)
        {
            this.Age = age;
            this.Manners = manners;
            this.SocialAnxiety = socialAnxiety;
            this.Optimism = optimism;
            this.Gender = gender;
            this.HomeRegion = homeRegion;
            this.LoveInterest = loveInterest;
            this.BirthSeason = birthSeason;
            this.BirthDay = birthDay;
        }
    }

    public class NPCAge
    {
        public const int ADULT = 0;
        public const int TEEN = 1;
        public const int CHILD = 2;
    }

    public class NPCManners
    {
        public const int NEUTRAL = 0;
        public const int POLITE = 1;
        public const int RUDE = 2;
    }

    public class NPCSocialAnxiety
    {
        public const int NEUTRAL = 0;
        public const int OUTGOING = 0;
        public const int SHY = 1;
    }

    public class NPCOptimism
    {
        public const int NEUTRAL = 0;
        public const int POSITIVE = 0;
        public const int NEGATIVE = 1;
    }

    public class NPCGender
    {
        public const int MALE = 0;
        public const int FEMALE = 1;
        public const int UNDEFINED = 2;
    }

    public class NPCHomeRegion
    {
        public const int OTHER = 0;
        public const int DESERT = 1;
        public const int TOWN = 2;
    }
}
