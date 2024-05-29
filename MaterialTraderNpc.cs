using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;

namespace MaterialTraderNpc
{
	class MaterialTraderNpc : Mod
	{
		public MaterialTraderNpc()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
			};
		}
	}
}
