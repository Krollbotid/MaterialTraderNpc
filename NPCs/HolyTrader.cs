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
	public class HolyTrader : ModNPC
	{
		public static bool VM = false;
		public override string Texture
		{
			get
			{
				return "MaterialTraderNpc/NPCs/HolyTrader";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Holy Trader";
			return mod.Properties.Autoload;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holy Trader");
            Main.npcFrameCount[npc.type] = 23;   
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
			animationType = NPCID.Wizard;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				return true;
			}
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == ItemID.PixieDust && Main.hardMode)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		
		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Greggory";
				case 1:
					return "Gaius";
				case 2:
					return "Crassus";
				default:
					return "Julius";
			}
		}

		public override string GetChat()
		{
			if (NPC.downedMechBoss2)
			{
				return "These mechanical eyes are very interesting, aren't they?";
			}
			switch (Main.rand.Next(3))
			{
				case 0:
					return "These unicorns are beautiful!";
				case 1:
					return "What a nice place! But Hallow is more nice then this wooden box.";
				default:
					return "I need more pixie dust!";
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
			        shop.item[nextSlot].SetDefaults (ItemID.PixieDust);
			        shop.item[nextSlot].shopCustomPrice = 3000;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.PearlstoneBlock);
			        shop.item[nextSlot].shopCustomPrice = 200;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.Pearlwood);
			        shop.item[nextSlot].shopCustomPrice = 250;
			        nextSlot++;
			        shop.item[nextSlot].SetDefaults (ItemID.RainbowBrick);
			        shop.item[nextSlot].shopCustomPrice = 7000;
			        nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.SoulofLight);
			        shop.item[nextSlot].shopCustomPrice = 3000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.CrystalShard);
			        shop.item[nextSlot].shopCustomPrice = 6000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.UnicornHorn);
			        shop.item[nextSlot].shopCustomPrice = 20000;
					nextSlot++;
                }

                if (NPC.downedPlantBoss)
			    {
				    shop.item[nextSlot].SetDefaults (ItemID.HallowedKey);
			        shop.item[nextSlot].shopCustomPrice = 10000000;
			        nextSlot++;
			    }
			}
			else
			{
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
				    if (NPC.downedMoonlord)
					{
					    shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("UnholyEssence"));
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
		projType = 79;
		}
		
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
		multiplier = 16f;
		}
	}
}