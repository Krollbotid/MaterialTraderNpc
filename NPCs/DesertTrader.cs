using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MaterialTraderNpc.NPCs
{
	[AutoloadHead]
	public class DesertTrader : ModNPC
	{
		public static bool VM = false;
		public override string Texture
		{
			get
			{
				return "MaterialTraderNpc/NPCs/DesertTrader";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Desert Trader";
			return mod.Properties.Autoload;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Trader");
            Main.npcFrameCount[npc.type] = 25;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 45;
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
						if (player.inventory[j].type == ItemID.AntlionMandible)
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
					return "Rostislav";
				case 1:
					return "Boris";
				case 2:
					return "Peter";
				default:
					return "Sergio";
			}
		}

		public override string GetChat()
		{
			if (Main.hardMode)
			{
				return "Can you defeat the crippy Sand Elemental?";
			}
			switch (Main.rand.Next(3))
			{
				case 0:
					return "I saw this huge pink thing on a cactus the other day..Any idea what that is?";
				case 1:
					return "You need a Sandstorm? Well I have just the recipe!?";
				default:
					return "Why does everybody think im a golden dye trader?";
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
			        shop.item[nextSlot].SetDefaults (ItemID.PinkPricklyPear);
			        shop.item[nextSlot].shopCustomPrice = 750;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.AntlionMandible);
					if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
					{
						shop.item[nextSlot].shopCustomPrice = 1250;
					}
					else
					{
						shop.item[nextSlot].shopCustomPrice = 900;
					}
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Cactus);
					shop.item[nextSlot].shopCustomPrice = 75;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Waterleaf);
			        shop.item[nextSlot].shopCustomPrice = 300;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.WaterleafSeeds);
			        shop.item[nextSlot].shopCustomPrice = 500;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.SandBlock);
			        shop.item[nextSlot].shopCustomPrice = 100;
				    nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.HardenedSand);
			        shop.item[nextSlot].shopCustomPrice = 75;
				    nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.Sandstone);
			        shop.item[nextSlot].shopCustomPrice = 75;
				    nextSlot++;
			    }

				if (NPC.downedBoss1)
				{
					shop.item[nextSlot].SetDefaults (ItemID.FossilOre);
			        shop.item[nextSlot].shopCustomPrice = 3000;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.DesertFossil);
			        shop.item[nextSlot].shopCustomPrice = 1000;
			        nextSlot++;
				}

				if (NPC.downedBoss2)
				{
				    shop.item[nextSlot].SetDefaults (ItemID.EbonsandBlock);
			        shop.item[nextSlot].shopCustomPrice = 100;
				    nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.CrimsandBlock);
			        shop.item[nextSlot].shopCustomPrice = 100;
				    nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.CorruptHardenedSand);
			        shop.item[nextSlot].shopCustomPrice = 75;
				    nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.CrimsonHardenedSand);
			        shop.item[nextSlot].shopCustomPrice = 75;
				    nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.CorruptSandstone);
			        shop.item[nextSlot].shopCustomPrice = 75;
				    nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.CrimsonSandstone);
			        shop.item[nextSlot].shopCustomPrice = 75;
				    nextSlot++;
				}

			    if (Main.hardMode)
			    {
					shop.item[nextSlot].SetDefaults (ItemID.PearlsandBlock);
			        shop.item[nextSlot].shopCustomPrice = 100;
				    nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.HallowHardenedSand);
			        shop.item[nextSlot].shopCustomPrice = 75;
				    nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.HallowSandstone);
			        shop.item[nextSlot].shopCustomPrice = 75;
				    nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.AncientCloth);
			        shop.item[nextSlot].shopCustomPrice = 4000;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.DarkShard);
			        shop.item[nextSlot].shopCustomPrice = 50000;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.LightShard);
			        shop.item[nextSlot].shopCustomPrice = 50000;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.DjinnLamp);
			        shop.item[nextSlot].shopCustomPrice = 150000;
				    nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.AncientBattleArmorMaterial);
			        shop.item[nextSlot].shopCustomPrice = 250000;
			   }
			}
			 
			else
			{
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("Talon"));
			            nextSlot++;
					}

					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("PharaohsBreath"));
			            shop.item[nextSlot].shopCustomPrice = 5000;
                        nextSlot++;
					}
				}//thorium(2)

				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
			        {
				        shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DesertFeather"));
                        nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("StormlionMandible"));
                        nextSlot++;
				    }
			    }

				if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
				{
				    if (NPC.downedBoss1)
			        {
				        shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("DesertEssence"));
						shop.item[nextSlot].shopCustomPrice = 10000;
					    nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("DiscordantAmber"));
			            shop.item[nextSlot].shopCustomPrice = 3200000;
                        nextSlot++;
				    }
			    }

				if (ModLoader.GetLoadedMods().Contains("imkSushisMod"))
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("SurfaceDesertToken"));
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
			projType = 599;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
		}
	}
}