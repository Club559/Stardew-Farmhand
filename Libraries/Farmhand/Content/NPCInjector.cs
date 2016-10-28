using Farmhand.API.NPCs;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmhand.Content
{
    public class NPCInjector : IContentInjector
    {
        public bool IsLoader => true;
        public bool IsInjector => false;

        public bool HandlesAsset(Type type, string asset)
        {
            string prefix = "";
            if (type == typeof(Texture2D))
            {
                prefix = "Portraits\\";
                if (asset.StartsWith(prefix) && NPCUtilities.NPCs.Any(_ => _.Value.Name == asset.Substring(prefix.Length)))
                    return true;
                prefix = "Characters\\";
                if (asset.StartsWith(prefix) && NPCUtilities.NPCs.Any(_ => _.Value.Name == asset.Substring(prefix.Length)))
                    return true;
            }
            else if(type == typeof(Dictionary<string,string>))
            {
                prefix = "Characters\\Dialogue\\";
                if (asset.StartsWith(prefix) && NPCUtilities.NPCs.Any(_ => _.Value.Name == asset.Substring(prefix.Length)))
                    return true;
                prefix = "Characters\\schedules\\";
                if (asset.StartsWith(prefix) && NPCUtilities.NPCs.Any(_ => _.Value.Name == asset.Substring(prefix.Length)))
                    return true;
            }
            return false;
        }
        
        public T Load<T>(ContentManager contentManager, string assetName)
        {
            object output = default(T);
            string prefix = "";
            if (typeof(T) == typeof(Texture2D))
            {
                prefix = "Portraits\\";
                if (assetName.StartsWith(prefix))
                {
                    output = NPCUtilities.NPCs.First(_ => _.Value.Name == assetName.Substring(prefix.Length)).Value.Portrait;
                }
                prefix = "Characters\\";
                if (assetName.StartsWith(prefix) && NPCUtilities.NPCs.Any(_ => _.Value.Name == assetName.Substring(prefix.Length)))
                {
                    output = NPCUtilities.NPCs.First(_ => _.Value.Name == assetName.Substring(prefix.Length)).Value.Spritesheet;
                }
            }
            else if (typeof(T) == typeof(Dictionary<string, string>))
            {
                prefix = "Characters\\Dialogue\\";
                if (assetName.StartsWith(prefix) && NPCUtilities.NPCs.Any(_ => _.Value.Name == assetName.Substring(prefix.Length)))
                {
                    output = NPCUtilities.NPCs.First(_ => _.Value.Name == assetName.Substring(prefix.Length)).Value.Dialogue;
                }
                prefix = "Characters\\schedules\\";
                if (assetName.StartsWith(prefix) && NPCUtilities.NPCs.Any(_ => _.Value.Name == assetName.Substring(prefix.Length)))
                {
                    output = NPCUtilities.NPCs.First(_ => _.Value.Name == assetName.Substring(prefix.Length)).Value.Schedule;
                }
            }
            return (T)output;
        }

        public void Inject<T>(T obj, string assetName, ref object output)
        {
            Logging.Log.Error("You shouldn't be here!");
            return;
        }
    }
}
