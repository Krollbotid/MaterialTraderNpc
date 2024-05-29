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
	public class SkyTrader : ModNPC
	{
		public static bool VM = false;
		public override string Texture
		{
			get
			{
				return "MaterialTraderNpc/NPCs/SkyTrader";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Sky Trader";
			return mod.Properties.Autoload;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sky Trader");
            Main.npcFrameCount[npc.type] = 25;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 45;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = -4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Merchant;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (!Main.hardMode)
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == ItemID.Feather)
						{
							return true;
						}
					}
				}
			}
			if (Main.hardMode)
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
					return "Prokhor";
				case 1:
					return "Roman";
				case 2:
					return "Pavel";
				default:
					return "Yaroslav";
			}
		}

		public override string GetChat()
		{
			if (Main.hardMode)
			{
				return "Can you defeat the Grand Wyvern?";
			}
			switch (Main.rand.Next(3))
			{
				case 0:
					return "Everyone like Space and Sky!";
				case 1:
					return "Do you want, I summon Rain?";
				default:
					return "Do you think that me is more living Travelling Merchant?";
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

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			if (VM)
			{
			    {
			        shop.item[nextSlot].SetDefaults (ItemID.Feather);
			        shop.item[nextSlot].shopCustomPrice = 750;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.SunplateBlock);
			        shop.item[nextSlot].shopCustomPrice = 500;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Cloud);
			        shop.item[nextSlot].shopCustomPrice = 200;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults (ItemID.Meteorite);
			        shop.item[nextSlot].shopCustomPrice = 450;
                    nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.FallenStar);
			        shop.item[nextSlot].shopCustomPrice = 300;
                    nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.RainCloud);
			        shop.item[nextSlot].shopCustomPrice = 3000;
			        nextSlot++;
			    }

			    if (Main.hardMode)
			    {
			        shop.item[nextSlot].SetDefaults (ItemID.SoulofFlight);
			        shop.item[nextSlot].shopCustomPrice = 10000;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.GiantHarpyFeather);
			        shop.item[nextSlot].shopCustomPrice = 75000;
			        nextSlot++;
			    }
			}
			 
			else
			{
				if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
				{
				    if (NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3)
			        {
				        shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("SkyEssence"));
			            shop.item[nextSlot].shopCustomPrice = 40000;
                        nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("StrangeTotem"));
			            shop.item[nextSlot].shopCustomPrice = 3200000;
                        nextSlot++;
				    }
				}

				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AvianCartilage"));
			        shop.item[nextSlot].shopCustomPrice = 4500;
			        nextSlot++;
				}

				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EssenceofCinder"));
			            shop.item[nextSlot].shopCustomPrice = 40000;
						nextSlot++;
					}

					if (NPC.downedMoonlord)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("ExodiumCluster"));
                        nextSlot++;
					}
				}

				if (ModLoader.GetLoadedMods().Contains("imkSushisMod"))
				{
					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("SpacePurityHardmodeToken"));
						shop.item[nextSlot].shopCustomPrice = 75000;
						nextSlot++;
					}

					else
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("SurfacePurityStartToken"));
						shop.item[nextSlot].shopCustomPrice = 50000;
						nextSlot++;
					}
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
			cooldown = 15;
			randExtraCooldown = 5;
		}
        
		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.MolotovCocktail;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
		}
	}
}