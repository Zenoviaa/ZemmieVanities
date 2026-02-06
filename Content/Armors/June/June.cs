using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZemmieVanities.Content.Armors.June
{
    public class JunePlayer : ModPlayer
    {
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            if(Player.name == "June")
            {
                return (IEnumerable<Item>)(object)new Item[3]
                {     
                    new Item(ModContent.ItemType<JunesMask>(), 1, 0),
                    new Item(ModContent.ItemType<JunesShirt>(), 1, 0),
                    new Item(ModContent.ItemType<JunesSkirt>(), 1, 0),
                };
            }
            return base.AddStartingItems(mediumCoreDeath);
        }
    }

    [AutoloadEquip(EquipType.Head)]
    public class JunesMask : ModItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.vanity = true;
        }

        public override void AddRecipes()
        {
            base.AddRecipes();
            CreateRecipe().AddIngredient(ItemID.Silk, 10).AddTile(TileID.Loom).Register();
        }
    }
    [AutoloadEquip(EquipType.Body)]
    public class JunesShirt : ModItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.vanity = true;
        }
        public override void AddRecipes()
        {
            base.AddRecipes();
            CreateRecipe().AddIngredient(ItemID.Silk, 10).AddTile(TileID.Loom).Register();
        }
    }

    [AutoloadEquip(EquipType.Legs)]
    public class JunesSkirt : ModItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.vanity = true;
        }

        public override void AddRecipes()
        {
            base.AddRecipes();
            CreateRecipe().AddIngredient(ItemID.Silk, 10).AddTile(TileID.Loom).Register();
        }
    }
}
