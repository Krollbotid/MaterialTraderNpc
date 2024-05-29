using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MaterialTraderNpc.NPCs
{
	[AutoloadHead]
	public class OceanTrader : ModNPC
	{
		public static bool VM = false;
		public override string Texture
		{
			get
			{
				return "MaterialTraderNpc/NPCs/OceanTrader";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Ocean Trader";
			return mod.Properties.Autoload;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ocean Trader");
            Main.npcFrameCount[npc.type] = 23;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 45;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 8;
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
			animationType = NPCID.Angler;
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
						if (player.inventory[j].type == ItemID.Coral || player.inventory[j].type == ItemID.Starfish)
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
					return "Arsen";
				case 1:
					return "Viktor";
				case 2:
					return "Illarion";
				default:
					return "Maximilian";
			}
		}

		public override string GetChat()
		{
			int desertTrader = NPC.FindFirstNPC(mod.NPCType("Desert Trader"));
			if (desertTrader >= 0 && Main.rand.Next(4) == 0)
				{
				     return "I met with " + Main.npc[desertTrader].GivenName + " on the beach.";
				}
			switch (Main.rand.Next(3))
			{
				case 0:
					return "A shark bit my toe off, when I was little.";
				case 1:
					return "I`m a great swimmer!";
				case 2:
					return "I stepped on a jellyfish yesterday,it was horrifying!";
				default:
					return "We have been making races with the angler, but he fell asleep.";
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
					shop.item[nextSlot].SetDefaults (ItemID.Coral);
			        shop.item[nextSlot].shopCustomPrice = 250;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Starfish);
			        shop.item[nextSlot].shopCustomPrice = 500;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Seashell);
			        shop.item[nextSlot].shopCustomPrice = 500;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.PalmWood);
			        shop.item[nextSlot].shopCustomPrice = 50;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.PinkJellyfish);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Glowstick);
			        shop.item[nextSlot].shopCustomPrice = 1000;
			        nextSlot++;
				}
				
				if (NPC.downedBoss1)
			    {
				    shop.item[nextSlot].SetDefaults (ItemID.SharkFin);
			        shop.item[nextSlot].shopCustomPrice = 500;
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.BlackInk);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.PurpleMucos);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
			    }
		    }

			else
			{
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("FishScale"));
                        nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("MarineKelp"));
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BrackMud"));
			            shop.item[nextSlot].shopCustomPrice = 80;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DangerShard"));
			            nextSlot++;
					}

					if (NPC.downedBoss1)
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("Aquaite"));
                        nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DepthScale"));
                        nextSlot++;
					}

					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AbyssalChitin"));
			            nextSlot++;
					}
				}//thorium(6)

				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
			        {
				        shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CloakingGland"));
                        nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("Tenebris"));
                        nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PlantyMush"));
                        nextSlot++;
				    }

					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("ChaoticOre"));
					    shop.item[nextSlot].shopCustomPrice = 25000;
						nextSlot++;
					}

					if(NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("Lumenite"));
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DepthCells"));
			            nextSlot++;
					}
			    }//calamity(3)

				if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
				{
				    if (NPC.downedFishron)
			        {
				        shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("WaterEssence"));
                        shop.item[nextSlot].shopCustomPrice = 75000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("OddWater"));
                        nextSlot++;
				    }
			    }//elements awoken (2)

				if (ModLoader.GetLoadedMods().Contains("imkSushisMod"))
				{
					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("FishingHardmodeToken"));
			            shop.item[nextSlot].shopCustomPrice = 75000;
						nextSlot++;
					}

					else
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("FishingStartToken"));
			        	shop.item[nextSlot].shopCustomPrice = 50000;
						nextSlot++;
					}
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("UnderwaterOceanStartToken"));
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
			projType = ProjectileID.PoisonedKnife;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
		}
	}
}