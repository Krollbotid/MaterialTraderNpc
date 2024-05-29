using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MaterialTraderNpc.NPCs
{
	[AutoloadHead]
	public class DungeonTrader : ModNPC
	{
		public static bool VM = false;
		public override string Texture
		{
			get
			{
				return "MaterialTraderNpc/NPCs/DungeonTrader";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Dungeon Trader";
			return mod.Properties.Autoload;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dungeon Trader");
            Main.npcFrameCount[npc.type] = 25;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 3;
			NPCID.Sets.AttackTime[npc.type] = 4;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 30;
			npc.defense = 25;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Merchant;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedBoss3)
			{
				return true;
			}
			return false;
		}
		
		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Markel";
				case 1:
					return "Platon";
				case 2:
					return "Adrian";
				default:
					return "Michael";
			}
		}

		public override string GetChat()
		{
			if (NPC.downedGolemBoss)
			{
				return "Why the cultists stay in the dungeon enter?";
			}
			switch (Main.rand.Next(3))
			{
				case 0:
					return "Everyone doesn`t like Dungeon!";
				case 1:
					return "Not only mechanic was caught by this ragpicker?";
				default:
					return "Is Mechanic a good companion?";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Vanilla materials";
			button2 = "Modded materials";
        }
 
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			VM = firstButton;
		    shop = true;
		}

		public bool CalamityDownedProvidence
        {
        get { return CalamityMod.CalamityWorld.downedProvidence; }
        }

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			if (VM)
			{
				{
			        shop.item[nextSlot].SetDefaults (ItemID.Bone);
			        shop.item[nextSlot].shopCustomPrice = 500;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.GoldenKey);
			        shop.item[nextSlot].shopCustomPrice = 95000;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Spike);
			        shop.item[nextSlot].shopCustomPrice = 250;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Book);
			        shop.item[nextSlot].shopCustomPrice = 500;
			        nextSlot++;
			    	shop.item[nextSlot].SetDefaults (ItemID.WaterCandle);
			        shop.item[nextSlot].shopCustomPrice = 10000;
			        nextSlot++;
			    }

			    if (NPC.downedPlantBoss)
			    {
			        shop.item[nextSlot].SetDefaults (ItemID.Ectoplasm);
			        shop.item[nextSlot].shopCustomPrice = 40000;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.BoneFeather);
			        shop.item[nextSlot].shopCustomPrice = 100000;
			        nextSlot++;
			    }
			}

			else
			{
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
			        if (NPC.downedBoss3)
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("SpiritDroplet"));			    
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DarksteelCore"));			    
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BrokenDarksteelHelmet"));			    
			            shop.item[nextSlot].shopCustomPrice = 5000;
						nextSlot++;
					}

					if (NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DarkMatter"));			    
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("HolyKnightsAlloy"));			    
			            nextSlot++;
					}
				}//thorium (4)

				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
					if (NPC.downedMoonlord)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm"));			    
			            nextSlot++;
					}
				}

				if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
				{
					if (NPC.downedMoonlord)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("Pyroplasm"));			    
			            shop.item[nextSlot].shopCustomPrice = 50000;
						nextSlot++;
					}
				}

				if (ModLoader.GetLoadedMods().Contains("imkSushisMod"))
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("UndergroundDungeonSkeletronToken"));
					if (Main.hardMode)
					{	
						shop.item[nextSlot].shopCustomPrice = 75000;
					}
					else
					{
						shop.item[nextSlot].shopCustomPrice = 50000;
					}
					nextSlot++;
				}
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			if (!Main.hardMode)
			{
			damage = 20;
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
			damage = 75;
			}
			if (NPC.downedMoonlord)
			{
			damage = 150;
			}
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 5;
			randExtraCooldown = 5;
		}

		public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)
		{
			scale = 1f;
			item = Main.itemTexture[ItemID.Muramasa]; 
			itemSize = 48;
		}

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
		{
			itemWidth = 48;
			itemHeight = 48;
		}
	}
}