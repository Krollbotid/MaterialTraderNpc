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
	public class WinterTrader : ModNPC
	{
		public static bool VM = false;
		public override string Texture
		{
			get
			{
				return "MaterialTraderNpc/NPCs/WinterTrader";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Winter Trader";
			return mod.Properties.Autoload;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Winter Trader");
            Main.npcFrameCount[npc.type] = 25;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = -6;
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
			animationType = NPCID.ArmsDealer;
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
						if (player.inventory[j].type == ItemID.SnowBlock || player.inventory[j].type == ItemID.IceBlock)
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
					return "Julian";
				case 1:
					return "Alex";
				case 2:
					return "Leo";
				default:
					return "Arseniy";
			}
		}

		public override string GetChat()
		{
			if (Main.hardMode)
			{
				return "Can you defeat the strong Ice Golem?";
			}
			switch (Main.rand.Next(3))
			{
				case 0:
					return "Everyone like Winter!";
				case 1:
					return "Do you want that I hit you by my snow?";
				default:
					return "Ya chukcha?";
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

		public bool CalamityDownedCryogen
		{
        get { return CalamityMod.CalamityWorld.downedCryogen; }
        }

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			if (VM)
			{
				{
			        shop.item[nextSlot].SetDefaults (ItemID.IceBlock);
			        shop.item[nextSlot].shopCustomPrice = 250;
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.SnowBlock);
			        shop.item[nextSlot].shopCustomPrice = 250;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.SlushBlock);
			        shop.item[nextSlot].shopCustomPrice = 250;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.BorealWood);
			        shop.item[nextSlot].shopCustomPrice = 50;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.CyanHusk);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Shiverthorn);
			        shop.item[nextSlot].shopCustomPrice = 200;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.ShiverthornSeeds);
			        shop.item[nextSlot].shopCustomPrice = 250;
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.Penguin);
			        shop.item[nextSlot].shopCustomPrice = 50000;
			        nextSlot++;
				}

				if (NPC.downedBoss2)
			    {
				    shop.item[nextSlot].SetDefaults (ItemID.RedIceBlock);
			        shop.item[nextSlot].shopCustomPrice = 250;
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.PurpleIceBlock);
			        shop.item[nextSlot].shopCustomPrice = 250;
			        nextSlot++;
			    }

				if (Main.hardMode)
			    {
			        shop.item[nextSlot].SetDefaults (ItemID.PinkIceBlock);
			        shop.item[nextSlot].shopCustomPrice = 250;
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.FrostCore);
			        shop.item[nextSlot].shopCustomPrice = 250000;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.IceFeather);
			        shop.item[nextSlot].shopCustomPrice = 75000;
			        nextSlot++;
			    }

				if (NPC.downedPlantBoss)
			    {
				    shop.item[nextSlot].SetDefaults (ItemID.FrozenKey);
			        shop.item[nextSlot].shopCustomPrice = 10000000;
			        nextSlot++;
			    }
			}
			
			else
			{
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("IcyShard"));
			            shop.item[nextSlot].shopCustomPrice = 700;
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("PenguinHead"));
			            shop.item[nextSlot].shopCustomPrice = 50;
			            nextSlot++;
					}
				}

				if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("PenguinFeather"));
			        shop.item[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
					
				    if (NPC.downedPlantBoss)
			        {
				        shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("FrostEssence"));
			            shop.item[nextSlot].shopCustomPrice = 60000;
                        nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("GlowingSlush"));
			            shop.item[nextSlot].shopCustomPrice = 3200000;
                        nextSlot++;
				    }
				}

				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
				    if (Main.hardMode)
			        {
				        shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EssenceofEleum"));
                        shop.item[nextSlot].shopCustomPrice = 40000;
						nextSlot++;
				    }

					if (CalamityDownedCryogen)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CryonicOre"));
                        nextSlot++;
					}
				}

				if (ModLoader.GetLoadedMods().Contains("imkSushisMod"))
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("UndergroundSnowStartToken"));
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
			cooldown = 15;
			randExtraCooldown = 5;
		}

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.FrostDaggerfish;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
		}
	}
}