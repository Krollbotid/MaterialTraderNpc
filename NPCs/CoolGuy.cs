using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.World.Generation;

namespace MaterialTraderNpc.NPCs
{
	[AutoloadHead]
	public class CoolGuy : ModNPC
	{
		public static bool FS = true;
		public static bool Cosmic = false;
		public static bool Bosses = false;
		public static bool Invasions = false;
		public static bool ButterflyV1 = false;
		public static bool Butterfly234 = false;
		public static bool FSalpha = false;
		public static bool Cosmicalpha = false;
		public static bool Bossesalpha = false;
		public static bool Invasionsalpha = false;
		public static bool ButterflyV1alpha = false;
		public static bool Butterfly234alpha = false;
		public override string Texture
		{
			get
			{
				return "MaterialTraderNpc/NPCs/CoolGuy";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Cool Guy";
			return mod.Properties.Autoload;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cool Guy");
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
            if (NPC.AnyNPCs(mod.NPCType("Jungle Trader")) || NPC.AnyNPCs(mod.NPCType("Winter Trader")) || NPC.AnyNPCs(mod.NPCType("Cavern Trader")) || NPC.AnyNPCs(mod.NPCType("Desert Trader")) || NPC.AnyNPCs(mod.NPCType("Dungeon Trader")) || NPC.AnyNPCs(mod.NPCType("Evil Trader")) || NPC.AnyNPCs(mod.NPCType("Hell Trader")) || NPC.AnyNPCs(mod.NPCType("Holy Trader")) || NPC.AnyNPCs(mod.NPCType("Ocean Trader")) || NPC.AnyNPCs(mod.NPCType("Sky Trader")))
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
					return "Cedric";
				case 1:
					return "Dominic";
				case 2:
					return "Adam";
				default:
					return "Blaze";
			}
		}

		public override string GetChat()
		{
			int JungleTrader = NPC.FindFirstNPC(mod.NPCType("JungleTrader"));
			if (JungleTrader >= 0 && Main.rand.Next(4) == 0)
			{
				return "I admire " + Main.npc[JungleTrader].GivenName + ". He is first from us appeared in this boring world.";
			}
			switch (Main.rand.Next(3))
			{
				case 0:
					return "I can sell you almost all materials in the world!";
				case 1:
					return "Yeah, i'm the coolest guy in the world!";
				default:
					return "Do you see my weapon? Just I`m cool.";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			if (FS)
			{
			    button = "Forest/Surface materials";
			    Butterfly234alpha = false;
			    FSalpha = true;
			}

			if (Cosmic)
			{
			    button = "Cosmic materials";
			    FSalpha = false;
			    Cosmicalpha = true;
			}

			if (Bosses)
			{
			    button = "Bosses' materials";
			    Cosmicalpha = false;
			    Bossesalpha = true;
			}

			if (Invasions)
			{
				button = "Invasions' materials";
			    Bossesalpha = false;
			    Invasionsalpha = true;
			}

			if (ButterflyV1)
			{
				button = "Butterflies Vanilla and Tier 1";
			    Invasionsalpha = false;
			    ButterflyV1alpha = true;
			}

			if (Butterfly234)
			{
				button = "Butterflies Tiers 2, 3 and 4";
			    ButterflyV1alpha = false;
			    Butterfly234alpha = true;
			}

			button2 = "Something else?";
        }
 
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
            {
                shop = true;
            }

		    else
			{
				if (FS && FSalpha)
				{
					Cosmic = true;
					FS = false;
				}

			    if (Cosmic && Cosmicalpha)
				{
				    Bosses = true;
					Cosmic = false;
				}

			    if (Bosses && Bossesalpha)
				{
					Invasions = true;
					Bosses = false;
				}

				if (Invasions && Invasionsalpha)
				{
					ButterflyV1 = true;
					Invasions = false;
				}

				if (ButterflyV1 && ButterflyV1alpha)
				{
					Butterfly234 = true;
					ButterflyV1 = false;
				}

				if (Butterfly234 && Butterfly234alpha)
				{
					FS = true;
					Butterfly234 = false;
				}
			}
		}

		public bool ThoriumDownedBird
        {
        get { return ThoriumMod.ThoriumWorld.downedThunderBird; }
        }
		public bool ThoriumDownedLich
        {
        get { return ThoriumMod.ThoriumWorld.downedLich; }
        }
		public bool ThoriumDownedRagnarok
        {
        get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
        }

		public bool CalamityDownedMind
        {
        get { return CalamityMod.CalamityWorld.downedHiveMind; }
        }
        public bool CalamityDownedPerforator
        {
        get { return CalamityMod.CalamityWorld.downedPerforator; }
        }
		public bool CalamityDownedSlime
        {
        get { return CalamityMod.CalamityWorld.downedSlimeGod; }
        }
		public bool CalamityDownedCalamitas
        {
        get { return CalamityMod.CalamityWorld.downedCalamitas; }
        }
		public bool CalamityDownedGhost
        {
        get { return CalamityMod.CalamityWorld.downedPolterghast; }
        }
		public bool CalamityDownedDeus
        {
        get { return CalamityMod.CalamityWorld.downedStarGod; }
        }
		public bool CalamityDownedBrimstone
        {
        get { return CalamityMod.CalamityWorld.downedBrimstoneElemental; }
        }
		public bool CalamityDownedRavager
        {
        get { return CalamityMod.CalamityWorld.downedScavenger; }
        }
		public bool CalamityDownedLevi
        {
        get { return CalamityMod.CalamityWorld.downedLeviathan; }
        }
		public bool CalamityDownedProvidence
        {
        get { return CalamityMod.CalamityWorld.downedProvidence; }
        }
		public bool CalamityDownedDOG
        {
        get { return CalamityMod.CalamityWorld.downedDoG; }
        }
		public bool CalamityDownedBirb
        {
        get { return CalamityMod.CalamityWorld.downedBumble; }
        }
		public bool CalamityDownedYharon
        {
        get { return CalamityMod.CalamityWorld.downedYharon; }
        }
		public bool CalamityDownedSCal
        {
        get { return CalamityMod.CalamityWorld.downedSCal; }
        }

		public bool EADownedEye
        {
        get { return ElementsAwoken.MyWorld.downedEye; }
		}
		public bool EADownedWyrm
        {
        get { return ElementsAwoken.MyWorld.downedAncientWyrm; }
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			if (FS)
			{
			    {
			        shop.item[nextSlot].SetDefaults (ItemID.Wood);
			        shop.item[nextSlot].shopCustomPrice = 50;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.Mushroom);
			        shop.item[nextSlot].shopCustomPrice = 100;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.YellowMarigold);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Daybloom);
			        shop.item[nextSlot].shopCustomPrice = 200;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.DaybloomSeeds);
			        shop.item[nextSlot].shopCustomPrice = 300;
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.BlueBerries);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.Sunflower);
			        shop.item[nextSlot].shopCustomPrice = 1000;
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.Pumpkin);
			        shop.item[nextSlot].shopCustomPrice = 100;
			        nextSlot++;
				    shop.item[nextSlot].SetDefaults (ItemID.Hay);
			        shop.item[nextSlot].shopCustomPrice = 50;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.Gel);
			        shop.item[nextSlot].shopCustomPrice = 50;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.PinkGel);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.Lens);
			        shop.item[nextSlot].shopCustomPrice = 250;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.BlackLens);
			        shop.item[nextSlot].shopCustomPrice = 5000;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.Seed);
			        shop.item[nextSlot].shopCustomPrice = 50;
			        nextSlot++;
			    }//vanilla (13)

				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
			        {
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("LivingLeaf"));
			            shop.item[nextSlot].shopCustomPrice = 700;
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("Blood"));		    
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("UnholyShards"));
			            nextSlot++;
					}

					if (NPC.downedBoss1)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AlienTech"));
						shop.item[nextSlot].shopCustomPrice = 10000;
			            nextSlot++;
					}

					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CarnivoreTail"));
			            nextSlot++;
					}
				}//thorium(2)

				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BloodOrb"));
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("WulfrumShard"));
			            nextSlot++;
					}

					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BlightedLens"));
			            nextSlot++;
					}
				}//calamity (3)

				if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("Puffball"));
			        nextSlot++;

					if (NPC.downedMoonlord)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("MortemiteDust"));
			        	shop.item[nextSlot].shopCustomPrice = 10000;
						nextSlot++;
					}
				}
				
				if (ModLoader.GetLoadedMods().Contains("imkSushisMod"))
				{
					if (NPC.downedBoss1)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("SurfacePurityEocToken"));
						shop.item[nextSlot].shopCustomPrice = 15000;
						nextSlot++;
					}

					else
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("SurfacePurityStartToken"));
						shop.item[nextSlot].shopCustomPrice = 10000;
						nextSlot++;
					}
				}
			}

			if (Cosmic)
			{	
				if (Main.hardMode)
				{
				    if (NPC.downedAncientCultist) 
					{
						shop.item[nextSlot].SetDefaults (ItemID.FragmentSolar);
			    	    shop.item[nextSlot].shopCustomPrice = 30000;
			    	    nextSlot++;
						shop.item[nextSlot].SetDefaults (ItemID.FragmentVortex);
			    	    shop.item[nextSlot].shopCustomPrice = 30000;
			    	    nextSlot++;
						shop.item[nextSlot].SetDefaults (ItemID.FragmentNebula);
			    	    shop.item[nextSlot].shopCustomPrice = 30000;
			    	    nextSlot++;
						shop.item[nextSlot].SetDefaults (ItemID.FragmentStardust);
			    	    shop.item[nextSlot].shopCustomPrice = 30000;
			    	    nextSlot++;
			    	}//vanilla(4)

					if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
					{
						if (NPC.downedAncientCultist)
						{
						    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CometFragment"));
			    	        nextSlot++;
						    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CelestialFragment"));
			    	        nextSlot++;
						}
					}//thorium(2)

					if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
					{
						if (NPC.downedAncientCultist)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("InfinityCrys"));
			    	        shop.item[nextSlot].shopCustomPrice = 500000;
							nextSlot++;
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("Stellorite"));
			    	        shop.item[nextSlot].shopCustomPrice = 200000;
							nextSlot++;
							if (NPC.downedMoonlord)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("GemOfTheUniverse"));
			    	        	shop.item[nextSlot].shopCustomPrice = 3200000;
                	        	nextSlot++;
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("VoidEssence"));
			    	            shop.item[nextSlot].shopCustomPrice = 150000;
                	            nextSlot++;
							}
						}
					}

					if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
					{
						if (NPC.downedAncientCultist)
						{
						    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("MeldBlob"));
			    	        shop.item[nextSlot].shopCustomPrice = 40000;
							nextSlot++;
						}

						{
						    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("Stardust"));
			    	        shop.item[nextSlot].shopCustomPrice = 15000;
							nextSlot++;
						}

						if (CalamityDownedDeus)
						{
						    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AstralOre"));
			    	        shop.item[nextSlot].shopCustomPrice = 25000;
							nextSlot++;
						}
					}//calamity(3)
				}
			}

			if (Bosses)
			{
				{
				    if (NPC.downedBoss2)
				    {
				    	if (WorldGen.crimson)
				    	{
				    		shop.item[nextSlot].SetDefaults (ItemID.TissueSample);
			                shop.item[nextSlot].shopCustomPrice = 1500;
			                nextSlot++;
				    	}
    
				    	if (!WorldGen.crimson)
				    	{
				    		shop.item[nextSlot].SetDefaults (ItemID.ShadowScale);
			                shop.item[nextSlot].shopCustomPrice = 1500;
			                nextSlot++;
				    	}
				    }

				    if (NPC.downedQueenBee)
				    {
				    	shop.item[nextSlot].SetDefaults (ItemID.BeeWax);
			            shop.item[nextSlot].shopCustomPrice = 2000;
			            nextSlot++;
				    }

					if (NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3)
					{
						shop.item[nextSlot].SetDefaults (ItemID.HallowedBar);
			            nextSlot++;
					}

				    if (NPC.downedMechBoss1)
				    {
				    	shop.item[nextSlot].SetDefaults (ItemID.SoulofMight);
			            shop.item[nextSlot].shopCustomPrice = 42000;
			            nextSlot++;
				    }
				    
				    if (NPC.downedMechBoss2)
				    {
				    	shop.item[nextSlot].SetDefaults (ItemID.SoulofSight);
			            shop.item[nextSlot].shopCustomPrice = 45000;
			            nextSlot++;
				    }
				    
				    if (NPC.downedMechBoss3)
				    {
				    	shop.item[nextSlot].SetDefaults (ItemID.SoulofFright);
			            shop.item[nextSlot].shopCustomPrice = 48000;
			            nextSlot++;
				    }
				    
				    if (NPC.downedMoonlord)
				    {
				    	shop.item[nextSlot].SetDefaults (ItemID.LunarOre);
			            shop.item[nextSlot].shopCustomPrice = 48000;
			            nextSlot++;
				    }
				}//vanilla(6)

				if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("BrokenToys"));
			        shop.item[nextSlot].shopCustomPrice = 2500;
					nextSlot++;

					if (NPC.downedBoss1)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("LensFragment"));
			        	shop.item[nextSlot].shopCustomPrice = 5000;
						nextSlot++;
					}

					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("CosmicShard"));
			            shop.item[nextSlot].shopCustomPrice = 10000;
						nextSlot++;
					}

					if (NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("MysticLeaf"));
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("MagicalHerbs"));
			            nextSlot++;
					}

					if (NPC.downedGolemBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("SunFragment"));
			            shop.item[nextSlot].shopCustomPrice = 50000;
						nextSlot++;
					}

					if (NPC.downedFishron)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("RoyalScale"));
			            shop.item[nextSlot].shopCustomPrice = 75000;
						nextSlot++;
					}

					if (EADownedWyrm || EADownedEye)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("TempleFragment"));
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("WyrmHeart"));
			            nextSlot++;
					}
				}//EA(7)

				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{  
					if (ThoriumDownedBird)
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("SandStone"));
					    nextSlot++;
				    }

					if (NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("StrangePlating"));			    
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("LifeCell"));			    
			            nextSlot++;
					}

					if (ThoriumDownedLich)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CursedCloth"));			    
			            nextSlot++;
					}

					if (NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BloomWeave"));			    
			            shop.item[nextSlot].shopCustomPrice = 3250;
						nextSlot++;
					}

					if (ThoriumDownedRagnarok)
					{
						{
						    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence"));
			                shop.item[nextSlot].shopCustomPrice = 150000;
			                nextSlot++;
						    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence"));
			                shop.item[nextSlot].shopCustomPrice = 150000;
			                nextSlot++;
						    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence"));
			                shop.item[nextSlot].shopCustomPrice = 150000;
			                nextSlot++;
						}

						if (Main.expertMode)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DormantHammer"));
			                nextSlot++;
						}
					}
				}//thorium(5)

				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{  
					if (NPC.downedBoss1)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("VictoryShard"));
					    nextSlot++;
					}

					if (CalamityDownedPerforator)
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BloodSample"));
					    shop.item[nextSlot].shopCustomPrice = 8000;
						nextSlot++;
				    }

					if (CalamityDownedMind)
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("TrueShadowScale"));
					    shop.item[nextSlot].shopCustomPrice = 8000;
						nextSlot++;
				    }

					if (CalamityDownedSlime)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PurifiedGel"));
					    shop.item[nextSlot].shopCustomPrice = 12000;
						nextSlot++;
					}

					if (CalamityDownedCalamitas)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CalamityDust"));
					    shop.item[nextSlot].shopCustomPrice = 40000;
						nextSlot++;
					}

					if (NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("LivingShard"));
			            shop.item[nextSlot].shopCustomPrice = 50000;
						nextSlot++;
					}

					if (CalamityDownedLevi)
					{
						if (!Main.hardMode)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("IOU"));
					        nextSlot++;
						}
					}

					if (CalamityDownedProvidence)
					{
						{
						    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DivineGeode"));
					        shop.item[nextSlot].shopCustomPrice = 300000;
							nextSlot++;
						}
						if (CalamityDownedCalamitas || CalamityDownedRavager || CalamityDownedBrimstone)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("Bloodstone"));
					        shop.item[nextSlot].shopCustomPrice = 100000;
							nextSlot++;
						}
					}

					if (CalamityDownedGhost)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("RuinousSoul"));
					    shop.item[nextSlot].shopCustomPrice = 600000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("ArmoredShell"));
					    shop.item[nextSlot].shopCustomPrice = 400000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DarkPlasma"));
					    shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("TwistingNether"));
					    shop.item[nextSlot].shopCustomPrice = 800000;
						nextSlot++;
					}

					if (CalamityDownedDOG)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CosmiliteBar"));
					    shop.item[nextSlot].shopCustomPrice = 1400000;
						nextSlot++;
					}

					if (CalamityDownedBirb)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EffulgentFeather"));
					    shop.item[nextSlot].shopCustomPrice = 1000000;
						nextSlot++;
					}

					if (CalamityDownedYharon)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("HellcasterFragment"));
					    nextSlot++;
					}

					if (CalamityDownedSCal)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CalamitousEssence"));
					    nextSlot++;
					}
				}//calamity(10)

				if (ModLoader.GetLoadedMods().Contains("imkSushisMod"))
				{
					if (NPC.downedMartians)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("LootMartiansToken"));
						if (NPC.downedMoonlord)
						{
							shop.item[nextSlot].shopCustomPrice = 80000;
						}
						shop.item[nextSlot].shopCustomPrice = 100000;
					}
					else
					{
						if (NPC.downedPlantBoss)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("LootPlanteraToken"));
							shop.item[nextSlot].shopCustomPrice = 85000;
						}
						else
						{
							if (NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("LootMechToken"));
								shop.item[nextSlot].shopCustomPrice = 75000;
							}
							else
							{
								if (NPC.downedPirates)
								{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("LootPiratesToken"));
									shop.item[nextSlot].shopCustomPrice = 60000;
								}
								else
								{
									if (Main.hardMode)
									{
										shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("LootHardmodeToken"));
										shop.item[nextSlot].shopCustomPrice = 50000;
									}
									else
									{
										if (NPC.downedBoss3)
										{
											shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("LootSkeletronToken"));
											shop.item[nextSlot].shopCustomPrice = 62500;
										}
										else
										{
											if (NPC.downedGoblins)
											{
												shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("LootGoblinsToken"));
												shop.item[nextSlot].shopCustomPrice = 25000;
											}
											else
											{
												shop.item[nextSlot].SetDefaults (ModLoader.GetMod("imkSushisMod").ItemType("LootStartToken"));
												shop.item[nextSlot].shopCustomPrice = 10000;
											}
										}
									}
								}
							}
						}
					}
					nextSlot++;
				}//imkSushisMod(1)
			}

			if (Invasions)
			{
				{
				    if (NPC.downedGoblins)
				    {
				    	shop.item[nextSlot].SetDefaults (ItemID.SpikyBall);
			            shop.item[nextSlot].shopCustomPrice = 75;
			            nextSlot++;
				    }
    
				    if (NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3) //solar eclipse
				    {
				    	shop.item[nextSlot].SetDefaults (ItemID.BrokenBatWing);
			            shop.item[nextSlot].shopCustomPrice = 100000;
			            nextSlot++;
    
				    	if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
				    	{
				    		shop.item[nextSlot].SetDefaults (ItemID.BrokenHeroSword);
			                shop.item[nextSlot].shopCustomPrice = 450000;
			                nextSlot++;
				    	}
				    }
    
				    if (NPC.downedPlantBoss) //Moons
				    {
				    	shop.item[nextSlot].SetDefaults (ItemID.SpookyWood);
			            shop.item[nextSlot].shopCustomPrice = 75;
			            nextSlot++;
    
				    	if (NPC.downedHalloweenTree) // mourning wood
				    	{
				    		shop.item[nextSlot].SetDefaults (ItemID.SpookyTwig);
			                shop.item[nextSlot].shopCustomPrice = 100000;
			                nextSlot++;
				    	}
    
				    	if (NPC.downedHalloweenKing) 
				    	{
				    		shop.item[nextSlot].SetDefaults (ItemID.BlackFairyDust);
			                shop.item[nextSlot].shopCustomPrice = 100000;
			                nextSlot++;
				    	}
				    }//Pumpkin Moon (NPC.downedChristmasTree for everscream NPC.downedChristmasSantank for Santa-NK1)
				    
				    if (NPC.downedMartians)
				    {
				        shop.item[nextSlot].SetDefaults (ItemID.MartianConduitPlating);
			            shop.item[nextSlot].shopCustomPrice = 75;
			            nextSlot++;
				    }
				}//vanilla(7)

				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
					if (NPC.downedGoblins)
				    {
				    	shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("Yew-Wood"));
			            nextSlot++;
				    }
    
				    if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
				    {
				    	shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BrokenHeroScythe"));
			            shop.item[nextSlot].shopCustomPrice = 300000;
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BrokenHeroStaff"));
			            shop.item[nextSlot].shopCustomPrice = 300000;
			            nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BrokenHeroBow"));
			            shop.item[nextSlot].shopCustomPrice = 300000;
			            nextSlot++;
				    }
				}//thorium(4)

				if (ModLoader.GetLoadedMods().Contains("ElementsAwoken"))
				{
					if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("BrokenHeroWhip"));
			            shop.item[nextSlot].shopCustomPrice = 250000;
						nextSlot++;
					}
				}

				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
					if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && CalamityDownedYharon)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DarksunFragment"));
			            nextSlot++;
					}

					if (NPC.downedHalloweenKing && CalamityDownedDOG)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("NightmareFuel"));
			            nextSlot++;
					}

					if (NPC.downedChristmasIceQueen && CalamityDownedDOG)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EndothermicEnergy"));
			            nextSlot++;
					}
				}//calamity(3)
			}

			if (ButterflyV1)
			{
				shop.item[nextSlot].SetDefaults (ItemID.GoldButterfly);
			    nextSlot++;

				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AmberButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AmethystButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AntlionButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BlinkrootButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BorderedButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DaybloomButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DiamondButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("EmeraldButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("FrozenButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("LifeCrystalButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("MushroomButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("RubyButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("SandButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("SapphireButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ShiverthornButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("SwallowtailButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("TopazButterfly"));
			    	nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("WaterleafButterfly"));
			    	nextSlot++;
				}
			}

			if (Butterfly234)
			{
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
					if (NPC.downedBoss2)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AncientWingButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AvianButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BloodiedButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CloudwingButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CorruptButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CrimsonButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DeathweedButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("EnergyWingButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("FireblossomButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("HellwingButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("JungleSporeButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("MeteorButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("SweetWingButterfly"));
						nextSlot++;
					}

					if (NPC.downedBoss3)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BoneButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BlueDungeonButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("GreenDungeonButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("PinkDungeonButterfly"));
						nextSlot++;
					}

					if (Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CursedFlameButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("FuschiaButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("HallowedButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("IchorButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("PinkMonarch"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("PixiewingButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ZereneButterfly"));
						nextSlot++;
					}

					if (NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ChlorophyteButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("EctoplasmicButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("LifeFruitButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ShroomiteButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("TempleButterfly"));
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("TotalityButterfly"));
						nextSlot++;
					}

					if (NPC.downedMoonlord)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("LuminiteButterfly"));
						nextSlot++;
					}
				}
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			if (!Main.hardMode)
			{
			damage = 50;
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
			damage = 188;
			}
			if (NPC.downedMoonlord)
			{
			damage = 375;
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
		projType = 283;
		}

		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
		{
		scale = 1f;
		closeness = 20;
		item = 1254;
		}
		
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
		multiplier = 16f;
		}
	}
}