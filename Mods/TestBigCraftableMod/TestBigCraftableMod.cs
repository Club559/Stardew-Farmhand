using Farmhand;
using Farmhand.API.Items;
using TestBigCraftableMod.BigCraftables;
using DebugMod;

namespace TestBigCraftableMod
{
    public class TestBigCraftableMod : Mod
    {
        public static TestBigCraftableMod Instance;

        public override void Entry()
        {
            Instance = this;

            Farmhand.Events.GameEvents.OnAfterLoadedContent += GameEvents_OnAfterLoadedContent;
            Farmhand.Events.PlayerEvents.OnFarmerChanged += PlayerEvents_OnFarmerChanged;

            Farmhand.API.Serializer.RegisterType<TestBigCraftable>();
        }

        private void GameEvents_OnAfterLoadedContent(object sender, System.EventArgs e)
        {
            BigCraftable.RegisterBigCraftable<TestBigCraftable>(TestBigCraftable.StaticInformation);
            Farmhand.API.Shops.ShopUtilities.AddToShopStock(Instance, Farmhand.API.Shops.Shops.Pierre, TestBigCraftable.StaticInformation);

            try { IntegrateDebugMod(); } catch { }
        }

        private void PlayerEvents_OnFarmerChanged(object sender, System.EventArgs e)
        {
            Farmhand.API.Player.Player.AddObject<TestBigCraftable>();
        }

        private void IntegrateDebugMod()
        {
            DebugMod.DebugMod.OnDebugInput += DebugMod_OnDebugInput;
        }

        private void DebugMod_OnDebugInput(object sender, DebugEventArgs e)
        {
            if (e.Args[0] == "testbig")
            {
                Farmhand.API.Player.Player.AddObject<TestBigCraftable>();
                e.Cancel = true;
            }
        }
    }
}
