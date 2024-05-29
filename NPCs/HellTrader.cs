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
	public class HellTrader : ModNPC
	{
		public static bool VM = false;
		public override string Texture
		{
			get
			{
				return "MaterialTraderNpc/NPCs/HellTrader";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Hell Trader";
			return mod.Properties.Autoload;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hell Trader");
            Main.npcFrameCount[npc.type] = 25;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 1;
			NPCID.Sets.AttackTime[npc.type] = 17;
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
			animationType = NPCID.DyeTrader;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedBoss2 && !Main.hardMode)
			{
				for (int k = 0; k < 255; k++)
				{
					Player player = Main.player[k];
					if (player.active)
					{
						for (int j = 0; j < player.inventory.Length; j++)
						{
							if (player.inventory[j].type == ItemID.Hellstone || player.inventory[j].type == ItemID.AshBlock)
							{
								return true;
							}
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
					return "Gleb";
				case 1:
					return "Izyaslav";
				case 2:
					return "Nicolas";
				default:
					return "Sherlock";
			}
		}

		public override string GetChat()
		{
			if (NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3)
			{
				return "I am afraid, the RED DEVIL will kill me.";
			}
			switch (Main.rand.Next(3))
			{
				case 0:
					return "I was born in a place where air is ash, and water is lava.";
				case 1:
					return "I am very grateful to you,thanks for saving me from the horrific hell.";
				default:
					return "I have never done anything important.";
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
			        shop.item[nextSlot].SetDefaults (ItemID.ObsidianBrick);
			        shop.item[nextSlot].shopCustomPrice = 500;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.AshBlock);
			        shop.item[nextSlot].shopCustomPrice = 50;
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.HellstoneBrick);
			        shop.item[nextSlot].shopCustomPrice = 500;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Fireblossom);
			        shop.item[nextSlot].shopCustomPrice = 250;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.FireblossomSeeds);
			        shop.item[nextSlot].shopCustomPrice = 400;
			        nextSlot++;
                }

                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults (ItemID.GuideVoodooDoll);
			        shop.item[nextSlot].shopCustomPrice = 175000;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.Hellstone);
			        shop.item[nextSlot].shopCustomPrice = 7000;
			        nextSlot++;
			    }
			
			    if (Main.hardMode)
			    {
			        shop.item[nextSlot].SetDefaults (ItemID.LivingFireBlock);
			        shop.item[nextSlot].shopCustomPrice = 50000;
			        nextSlot++;
			    }

			    if (NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3)
			    {
                    shop.item[nextSlot].SetDefaults (ItemID.FireFeather);
			        shop.item[nextSlot].shopCustomPrice = 100000;
			        nextSlot++;
			    }
			}
			else
			{
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("MoltenResidue"));			    
			            nextSlot++;
					}//thorium(1)
				}
				
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
			        {
				        shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DemonicBoneAsh"));
                        nextSlot++;
				    }

					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EssenceofChaos"));
                        shop.item[nextSlot].shopCustomPrice = 40000;
						nextSlot++;
					}

					if (NPC.downedMoonlord)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("UnholyEssence"));
                        nextSlot++;
					}
			    }//calamity(2)
				
				if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
				{
				    {
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("ImpEar"));
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("FleshClump"));
			            shop.item[nextSlot].shopCustomPrice = 5000;
                        nextSlot++;
					}
					
					if (NPC.downedBoss3)
			        {
				        shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("FireEssence"));
			            shop.item[nextSlot].shopCustomPrice = 20000;
                        nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("FieryJar"));
			            shop.item[nextSlot].shopCustomPrice = 3200000;
                        nextSlot++;
				    }

					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("DemonicFleshClump"));
			            shop.item[nextSlot].shopCustomPrice = 5000;
                        nextSlot++;
					}
			    }

				if (ModLoader.GetLoadedMods().Contains("imkSushisMod"))
				{
					if (NPC.downedBoss3)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("UnderworldHellSkeletronToken"));
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
		projType = 41;
		}

		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
		{
		scale = 1f;
		closeness = 20;
		item = 120;
		}
		
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
		multiplier = 16f;
		}
	}
}