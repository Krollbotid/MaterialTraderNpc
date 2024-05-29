using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MaterialTraderNpc.NPCs
{
	[AutoloadHead]
	public class CavernTrader : ModNPC
	{
		public static bool VM = false;
		public override string Texture
		{
			get
			{
				return "MaterialTraderNpc/NPCs/CavernTrader";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Cavern Trader";
			return mod.Properties.Autoload;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cavern Trader");
            Main.npcFrameCount[npc.type] = 23;   
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
			animationType = NPCID.Mechanic;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (!Main.hardMode)
			{   
				for (int k = 0; k < 255; k++)
			    {
			    	Player player = Main.player[k];
			    	if (player.active)
			    	{
			    		for (int j = 0; j < player.inventory.Length; j++)
			    		{
			    			if (player.inventory[j].type == ItemID.Blinkroot || player.inventory[j].type == ItemID.Cobweb)
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
					return "Zoya";
				case 1:
					return "Proskoviya";
				case 2:
					return "Ekaterina";
				default:
					return "Elizabet";
			}
		}

		public override string GetChat()
		{
			int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
			if (!(mechanic >= 0 && Main.rand.Next(4) == 0))
			{
				return "When you rescue the Mechanic";
			}
			switch (Main.rand.Next(3))
			{
				case 0:
					return "I became a miner, but my elder sister is a mechanic.";
				case 1:
					return "By statistics, 70% of all Terraria players purchase rubies from me.";
				default:
					return "I don't know where my younger sister is.";
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

		public bool ThoriumDownedCoznix
        {
        get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
        }
		
		public bool CalamityDownedProvidence
		{
        get { return CalamityMod.CalamityWorld.downedProvidence; }
        }
		public bool CalamityDownedYharon
		{
		get { return CalamityMod.CalamityWorld.downedYharon; }
		}
		public bool CalamityDownedMind
        {
        get { return CalamityMod.CalamityWorld.downedHiveMind; }
        }
        public bool CalamityDownedPerforator
        {
        get { return CalamityMod.CalamityWorld.downedPerforator; }
        }

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			if (VM)
			{
			    {
		            shop.item[nextSlot].SetDefaults (ItemID.Amethyst);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Topaz);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Sapphire);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Emerald);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Ruby);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Diamond);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.CopperOre);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.TinOre);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.IronOre);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.LeadOre);
			        nextSlot++;
			    	shop.item[nextSlot].SetDefaults (ItemID.Cobweb);
			        shop.item[nextSlot].shopCustomPrice = 50;
			        nextSlot++;
			    	shop.item[nextSlot].SetDefaults (ItemID.Blinkroot);
			        shop.item[nextSlot].shopCustomPrice = 300;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.BlinkrootSeeds);
			        shop.item[nextSlot].shopCustomPrice = 350;
			        nextSlot++;
			    }

			    if (NPC.downedBoss1)
			    {
			    	shop.item[nextSlot].SetDefaults (ItemID.SilverOre);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.TungstenOre);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.GoldOre);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.PlatinumOre);
			        nextSlot++;
			    	shop.item[nextSlot].SetDefaults (ItemID.DemoniteOre);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.CrimtaneOre);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.GlowingMushroom);
			        shop.item[nextSlot].shopCustomPrice = 400;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.MushroomGrassSeeds);
			        shop.item[nextSlot].shopCustomPrice = 1600;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.RedHusk);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
			    	shop.item[nextSlot].SetDefaults (ItemID.Hook);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
			    	shop.item[nextSlot].SetDefaults (ItemID.BlueJellyfish);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
			    	shop.item[nextSlot].SetDefaults (ItemID.TealMushroom);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
			    	shop.item[nextSlot].SetDefaults (ItemID.LimeKelp);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
			    	shop.item[nextSlot].SetDefaults (ItemID.OrangeBloodroot);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
			    }
			
			    if (NPC.downedBoss2)
			    {
				    shop.item[nextSlot].SetDefaults (ItemID.Obsidian);
				    shop.item[nextSlot].shopCustomPrice = 2500;
			        nextSlot++;
			    }

			    if (Main.hardMode)
			    {
					shop.item[nextSlot].SetDefaults (ItemID.LifeCrystal);
			        shop.item[nextSlot].shopCustomPrice = 8500;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.CobaltOre);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.PalladiumOre);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.MythrilOre);
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.OrichalcumOre);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.AdamantiteOre);
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.TitaniumOre);
				    nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.GreenJellyfish);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
			    }
				
				else if (NPC.downedBoss3)
				{
					shop.item[nextSlot].SetDefaults (ItemID.LifeCrystal);
			        shop.item[nextSlot].shopCustomPrice = 75000;
			        nextSlot++;
			    }
			}

			else
			{
				if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("Drakonite"));			    
			        nextSlot++;
				}

				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DangerShard"));
			            shop.item[nextSlot].shopCustomPrice = 7500;
			            nextSlot++;
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ThoriumOre"));
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("SmoothCoal"));
			            shop.item[nextSlot].shopCustomPrice = 1500;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("Onyx"));
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("Opal"));
			            shop.item[nextSlot].shopCustomPrice = 5000;
			            nextSlot++;
					}

					if (NPC.downedBoss2)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("MagmaOre"));
			            nextSlot++;
					}

					if (NPC.downedBoss3)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("GraniteEnergyCore"));
			            nextSlot++;
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BronzeFragments"));
			            nextSlot++;
					}

					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CeruleanMorel"));			    
			            nextSlot++;
					}

					if (ThoriumDownedCoznix)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("LodeStoneChunk"));			    
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ValadiumChunk"));			    
			            nextSlot++;
					}

					if (NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("IllumiteChunk"));			    
			            nextSlot++;
					}
				}//thorium(12)

				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
				    {
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AncientBoneDust"));
			            shop.item[nextSlot].shopCustomPrice = 7500;
			            nextSlot++;
					}

					if (CalamityDownedMind || CalamityDownedPerforator)
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AerialiteOre"));			    
			            shop.item[nextSlot].shopCustomPrice = 8000;			            			            
						nextSlot++;
					}

					if (NPC.downedPlantBoss)
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PerennialOre"));			    
			            shop.item[nextSlot].shopCustomPrice = 30000;
						nextSlot++;
					}

					if (CalamityDownedProvidence)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("UelibloomOre"));
						shop.item[nextSlot].shopCustomPrice = 50000;
						nextSlot++;
					}

					if (CalamityDownedYharon)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AuricOre"));			    
			            nextSlot++;
					}
				}//calamity(10)

				if (ModLoader.GetLoadedMods().Contains("imkSushisMod"))
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("UndergroundPurityStartToken"));
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
			projType = ProjectileID.Grenade;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
		}
	}
}