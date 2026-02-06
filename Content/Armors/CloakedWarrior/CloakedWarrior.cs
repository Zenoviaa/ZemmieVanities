using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZemmieVanities.Content.Armors.CloakedWarrior
{
    public class CloakedWarriorCloakBackDrawLayer : PlayerDrawLayer
    {
        private Asset<Texture2D> _cloakTextureAsset;
        public override bool IsHeadLayer => false;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            _cloakTextureAsset = ModContent.Request<Texture2D>(ModContent.GetInstance<CloakedWarriorBody>().Texture + "_CloakBack");
        }

        public override void Unload()
        {
            base.Unload();
            _cloakTextureAsset = null;
        }

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            return drawInfo.drawPlayer.body == ModContent.GetInstance<CloakedWarriorBody>().Item.bodySlot;
        }

        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Torso);
        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            var position = drawInfo.Center - Main.screenPosition;
            position = new Vector2((int)position.X, (int)position.Y);
            position.Y += 6;
            Rectangle bodyFrame = drawInfo.drawPlayer.bodyFrame;
            float yOsc = MathF.Sin(bodyFrame.Y) * 0.5f + 0.5f;
            position.Y += yOsc * 2;

            float rotation = yOsc * MathHelper.ToRadians(5);

            SpriteEffects spriteEffects = drawInfo.drawPlayer.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            drawInfo.DrawDataCache.Add(new DrawData(
                _cloakTextureAsset.Value,
                position,
                null,
                Color.White,
                rotation, 
                _cloakTextureAsset.Size() * 0.5f,
                1f,
                spriteEffects,
                0
            ));
        }
    }

    public class CloakedWarriorCloakDrawLayer : PlayerDrawLayer
    {
        private Asset<Texture2D> _cloakTextureAsset;
        public override bool IsHeadLayer => false;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            _cloakTextureAsset = ModContent.Request<Texture2D>(ModContent.GetInstance<CloakedWarriorBody>().Texture + "_CloakFront");
        }
        public override void Unload()
        {
            base.Unload();
            _cloakTextureAsset = null;
        }
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            return drawInfo.drawPlayer.body == ModContent.GetInstance<CloakedWarriorBody>().Item.bodySlot;

        }

        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.ProjectileOverArm);
        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            var position = drawInfo.Center - Main.screenPosition;
            position = new Vector2((int)position.X, (int)position.Y);
            position.Y += 6;

            Rectangle bodyFrame = drawInfo.drawPlayer.bodyFrame;
            float yOsc = MathF.Sin(bodyFrame.Y) * 0.5f + 0.5f;
            position.Y += yOsc * 2;
            float rotation = yOsc * MathHelper.ToRadians(5);
            SpriteEffects spriteEffects = drawInfo.drawPlayer.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            drawInfo.DrawDataCache.Add(new DrawData(
                _cloakTextureAsset.Value,
                position,
                null,
                Color.White,
                rotation,
                _cloakTextureAsset.Size() * 0.5f,
                1f,
               spriteEffects,
                0
            ));
        }
    }

    [AutoloadEquip(EquipType.Head)]
    public class CloakedWarriorMask : ModItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.vanity = true;
        }

        public override void AddRecipes()
        {
            base.AddRecipes();
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.Bone, 1)
                .AddTile(TileID.Loom).Register();
        }
    }

    [AutoloadEquip(EquipType.Body)]
    public class CloakedWarriorBody : ModItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.vanity = true;
        }
        public override void AddRecipes()
        {
            base.AddRecipes();
            CreateRecipe()
                   .AddIngredient(ItemID.Silk, 10)
                   .AddIngredient(ItemID.Bone, 1)
                   .AddTile(TileID.Loom).Register();
        }
      
    }

    [AutoloadEquip(EquipType.Legs)]
    public class CloakedWarriorLegs : ModItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.vanity = true;
        }

        public override void AddRecipes()
        {
            base.AddRecipes();
            CreateRecipe()
                 .AddIngredient(ItemID.Silk, 10)
                 .AddIngredient(ItemID.Bone, 1)
                 .AddTile(TileID.Loom).Register();
        }
    }
}
