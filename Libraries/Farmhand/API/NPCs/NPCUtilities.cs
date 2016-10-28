using Microsoft.Xna.Framework;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmhand.API.NPCs
{
    public class NPCUtilities
    {
        public static Dictionary<string, NPCInformation> NPCs { get; } = new Dictionary<string, NPCInformation>();

        public static void RegisterNPC<T>(Mod owner, NPCInformation info)
        {
            info.Owner = owner;
            info.ClassType = typeof(T);
            if (!Serializer.InjectedTypes.Contains(typeof(T)))
                Serializer.RegisterType<T>();
            if (NPCs.ContainsKey(info.Name))
            {
                Logging.Log.Error($"Failed to register NPC {info.Name} from mod {owner.ModSettings.Name} - Already registered by mod {NPCs[info.Name].Owner.ModSettings.Name}");
                return;
            }
            NPCs.Add(info.Name, info);
        }

        public static void RegisterNPC(Mod owner, NPCInformation info)
        {
            RegisterNPC<NPC>(owner, info);
        }

        public static NPC CreateNPC(NPCInformation info, bool spawn = false)
        {
            //NPC npc = new NPC(new AnimatedSprite(info.Spritesheet, 0, info.Width, info.Height), new Vector2(info.StartingX, info.StartingY) * Game1.tileSize, info.StartingMap, info.Facing, info.Name, info.Datable, null, info.Portrait);
            if (info == null)
            {
                Logging.Log.Error("Failed to create NPC, info is null");
                return null;
            }
            if(!typeof(NPC).IsAssignableFrom(info.ClassType))
            {
                Logging.Log.Error($"Failed to create NPC: {info.Name} | Type {info.ClassType?.FullName ?? "null"} is not an extension of StardewValley.NPC.");
                return null;
            }

            try
            {
                NPC npc = Activator.CreateInstance(info.ClassType, new AnimatedSprite(info.Spritesheet, 0, info.Width, info.Height), new Vector2(info.StartingX, info.StartingY) * Game1.tileSize, info.StartingMap, info.Facing, info.Name, info.Datable, null, info.Portrait) as NPC;
                if (info.GiftTastes != null && !Game1.NPCGiftTastes.ContainsKey(npc.name))
                    Game1.NPCGiftTastes.Add(npc.name, info.GiftTastes);
                if (spawn)
                    Game1.getLocationFromName(info.StartingMap).addCharacter(npc);
                return npc;
            }
            catch(Exception e)
            {
                Logging.Log.Error($"Failed to create NPC: {info.Name}");
                Logging.Log.Error(e.ToString());
                return null;
            }
        }

        public static NPC CreateNPC(string name, bool spawn = false) => NPCs.ContainsKey(name) ? CreateNPC(NPCs[name], spawn) : null;

        public static bool CanCreateNPC(string name) => Game1.hasLoadedGame && Game1.getCharacterFromName(name) == null;
    }
}
