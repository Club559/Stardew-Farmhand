using Farmhand;
using Farmhand.API.NPCs;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNPCMod.NPCs;

namespace TestNPCMod
{
    public class TestNPCMod : Mod
    {
        public static TestNPCMod Instance;

        public override void Entry()
        {
            Instance = this;

            Farmhand.API.Serializer.RegisterType<TestNPC>();

            Farmhand.Events.GameEvents.OnAfterLoadedContent += GameEvents_OnAfterLoadedContent;
            Farmhand.Events.GameEvents.OnBeforeUpdateTick += GameEvents_OnBeforeUpdateTick;
        }

        private void GameEvents_OnBeforeUpdateTick(object sender, Farmhand.Events.Arguments.GameEvents.EventArgsOnBeforeGameUpdate e)
        {
            if(NPCUtilities.CanCreateNPC("Ashley"))
                NPCUtilities.CreateNPC("Ashley", true);
        }

        private void GameEvents_OnAfterLoadedContent(object sender, EventArgs e)
        {
            NPCUtilities.RegisterNPC<TestNPC>(this, TestNPC.Information);
        }
    }
}
