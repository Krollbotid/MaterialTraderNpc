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
	public class EvilTrader : ModNPC
	{
		public static bool VM = false;
		public override string Texture
		{
			get
			{
				return "MaterialTraderNpc/NPCs/EvilTrader";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Evil Trader";
			return mod.Properties.Autoload;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Evil Trader");
            Main.npcFrameCount[npc.type] = 23;   
			NPCID.Sets.AttackFrameCount[npc.type] = 2;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 22;
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
			npc.damage = 30;
			npc.defense = 25;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Clothier;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedBoss1 && !Main.hardMode)
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == ItemID.RottenChunk || player.inventory[j].type == ItemID.Vertebrae)
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
					return "Anthony";
				case 1:
					return "Damien";
				case 2:
					return "Nathan";
				default:
					return "Arsak";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(3))
			{
				case 0:
					return "Don't go to the horrific place I went through!";
				case 1:
					return "Going through that evil was so terrible.";
				default:
					return "id you see my horns? I got them after the 5th day here!";
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
				if (WorldGen.crimson)
			    {
			        shop.item[nextSlot].SetDefaults (ItemID.Vertebrae);
			        shop.item[nextSlot].shopCustomPrice = 200;
					nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.ViciousMushroom);
			        shop.item[nextSlot].shopCustomPrice = 180;
					nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Shadewood);
			        shop.item[nextSlot].shopCustomPrice = 50;
					nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.CrimstoneBlock);
			        shop.item[nextSlot].shopCustomPrice = 75;
					nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.Deathweed);
			        shop.item[nextSlot].shopCustomPrice = 300;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.DeathweedSeeds);
			        shop.item[nextSlot].shopCustomPrice = 350;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.CrimsonSeeds);
			        shop.item[nextSlot].shopCustomPrice = 400;
					nextSlot++;
			    }

				if (!WorldGen.crimson)
			    {
			        shop.item[nextSlot].SetDefaults (ItemID.RottenChunk);
			        shop.item[nextSlot].shopCustomPrice = 200;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.WormTooth);
			        shop.item[nextSlot].shopCustomPrice = 400;
					nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.VileMushroom);
			        shop.item[nextSlot].shopCustomPrice = 180;
					nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Ebonwood);
			        shop.item[nextSlot].shopCustomPrice = 50;
					nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.EbonstoneBlock);
			        shop.item[nextSlot].shopCustomPrice = 75;
					nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.Deathweed);
			        shop.item[nextSlot].shopCustomPrice = 300;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.DeathweedSeeds);
			        shop.item[nextSlot].shopCustomPrice = 350;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.CorruptSeeds);
			        shop.item[nextSlot].shopCustomPrice = 400;
					nextSlot++;
			    }
			
			    if (Main.hardMode)
			    {
			        {
					    shop.item[nextSlot].SetDefaults (ItemID.SoulofNight);
			            shop.item[nextSlot].shopCustomPrice = 3000;
						nextSlot++;
					}
					
					if (!WorldGen.crimson)
					{
			            shop.item[nextSlot].SetDefaults (ItemID.CursedFlame);
			            shop.item[nextSlot].shopCustomPrice = 4000;
						nextSlot++;
					}

					if (WorldGen.crimson)
					{
			            shop.item[nextSlot].SetDefaults (ItemID.Ichor);
			            shop.item[nextSlot].shopCustomPrice = 4000;
						nextSlot++;
					}
				}
		    
			    if (NPC.downedPlantBoss)
			    {
				    if (!WorldGen.crimson)
					{
			            shop.item[nextSlot].SetDefaults (ItemID.CorruptionKey);
			            shop.item[nextSlot].shopCustomPrice = 10000000;
			            nextSlot++;
					}

					if (WorldGen.crimson)
					{
			            shop.item[nextSlot].SetDefaults (ItemID.CrimsonKey);
			            shop.item[nextSlot].shopCustomPrice = 10000000;
			            nextSlot++;
					}
			    }
			}

			else
			{
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
					if (Main.hardMode)
					{
						if (WorldGen.crimson)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("GreenDragonScale"));
			                nextSlot++;
						}

						if (!WorldGen.crimson)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("UnfathomableFlesh"));
			                nextSlot++;
						}					
					}
				}//thorium (1)

				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BloodlettingEssence"));
			            nextSlot++;
					}

					if (!WorldGen.crimson)
					{
			            shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("FetidEssence"));
			            nextSlot++;
					}

					if (NPC.downedBoss3)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EbonianGel"));
			            shop.item[nextSlot].shopCustomPrice = 3000;
						nextSlot++;
					}

					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("MurkySludge"));
			            nextSlot++;
					}
				}

				if (ModLoader.GetLoadedMods().Contains("imkSushisMod"))
				{
					if (NPC.downedBoss1)
					{
						if (WorldGen.crimson)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("UndergroundCrimsonEocToken"));
						}
						else
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("UndergroundCorruptionEocToken"));
						}
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
		projType = 45;
		}
		
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
		multiplier = 16f;
		}
	}
}