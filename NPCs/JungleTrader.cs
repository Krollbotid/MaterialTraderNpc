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
	public class JungleTrader : ModNPC
	{
		public static bool VM = false;
		public override string Texture
		{
			get
			{
				return "MaterialTraderNpc/NPCs/JungleTrader";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Jungle Trader";
			return mod.Properties.Autoload;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle Trader");
            Main.npcFrameCount[npc.type] = 25;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 1;
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = -3;
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
			if (!Main.hardMode)
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == ItemID.JungleSpores || player.inventory[j].type == ItemID.Stinger)
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
					return "Max";
				case 1:
					return "Alex";
				case 2:
					return "Aivan";
				default:
					return "Oscold";
			}
		}

		public override string GetChat()
		{
			int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
			if (witchDoctor >= 0 && Main.rand.Next(4) == 0)
			{
				return "Can you ask " + Main.npc[witchDoctor].GivenName + " why he was waiting for you to defeat Queen Bee?";
			}
			switch (Main.rand.Next(3))
			{
				case 0:
					return "Everyone likes Jungle!";
				case 1:
					return "Do you want me to hit you with my stinger?";
				default:
					return "How the author made me?";
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
			        shop.item[nextSlot].SetDefaults (ItemID.RichMahogany);
			        shop.item[nextSlot].shopCustomPrice = 50;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.JungleGrassSeeds);
			        shop.item[nextSlot].shopCustomPrice = 2500;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Moonglow);
			        shop.item[nextSlot].shopCustomPrice = 250;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.MoonglowSeeds);
			        shop.item[nextSlot].shopCustomPrice = 400;
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.Frog);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.Grubby);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.Sluggy);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
			    }

			    if (NPC.downedBoss1)
			    {
					shop.item[nextSlot].SetDefaults (ItemID.VioletHusk);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.SkyBlueFlower);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.JungleSpores);
			        shop.item[nextSlot].shopCustomPrice = 500;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.Stinger);
			        shop.item[nextSlot].shopCustomPrice = 1500;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.Vine);
			        shop.item[nextSlot].shopCustomPrice = 1000;
			        nextSlot++;
			    }

				if (NPC.downedBoss2)
				{
					shop.item[nextSlot].SetDefaults (ItemID.Hive);
			        shop.item[nextSlot].shopCustomPrice = 1000;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.HoneyBlock);
			        shop.item[nextSlot].shopCustomPrice = 750;
			        nextSlot++;
				}

			    if (Main.hardMode)
			    {
			        shop.item[nextSlot].SetDefaults (ItemID.TurtleShell);
			        shop.item[nextSlot].shopCustomPrice = 200000;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.ButterflyDust);
			        shop.item[nextSlot].shopCustomPrice = 75000;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.TatteredBeeWing);
			        shop.item[nextSlot].shopCustomPrice = 75000;
			        nextSlot++;
			    }

			    if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			    {
				    shop.item[nextSlot].SetDefaults (ItemID.ChlorophyteOre);
			        shop.item[nextSlot].shopCustomPrice = 3200;
			        nextSlot++;
				}
		    
			    if (NPC.downedPlantBoss)
			    {
				    shop.item[nextSlot].SetDefaults (ItemID.LifeFruit);
			        shop.item[nextSlot].shopCustomPrice = 50000;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.LunarTabletFragment);
			        shop.item[nextSlot].shopCustomPrice = 35000;
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.JungleKey);
			        shop.item[nextSlot].shopCustomPrice = 10000000;
			        nextSlot++;
			    }
			}

			else
			{
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("Petal"));
			            shop.item[nextSlot].shopCustomPrice = 5500;
			            nextSlot++;
					}

					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BioMatter"));
			            nextSlot++;
					}
					
					if (NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("SolarPebble"));			    
			            nextSlot++;
					}
				}//thorium(3)

				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("ManeaterBulb"));
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("MurkyPaste"));
			            nextSlot++;
					}

					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BeetleJuice"));
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("GypsyPowder"));
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("TrapperBulb"));
			            nextSlot++;
					}

					if (NPC.downedGolemBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PlagueCellCanister"));
			            nextSlot++;
					}
				}//calamity(6)

				if (ModLoader.GetLoadedMods().Contains("imkSushisMod"))
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("UndergroundJungleStartToken"));
					if (Main.hardMode)
					{	
						shop.item[nextSlot].shopCustomPrice = 75000;
					}
					else
					{
						shop.item[nextSlot].shopCustomPrice = 50000;
					}
					nextSlot++;
					
					if (NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("TempleJunglePlanteraToken"));
						shop.item[nextSlot].shopCustomPrice = 75000;
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
		cooldown = 5;
		randExtraCooldown = 5;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
		attackDelay = 10;
		projType = 469;
		}

		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
		{
		scale = 1f;
		closeness = 20;
		item = 2888;
		}
		
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
		multiplier = 16f;
		}
	}
}