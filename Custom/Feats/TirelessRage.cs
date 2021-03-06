using System;
using Server;
using System.IO;
using System.Text;
using Server.Network;
using Server.Mobiles;

namespace Server.FeatInfo
{
	public class TirelessRage : BaseFeat
	{
		public override string Name{ get{ return "Tireless Rage"; } }
		public override FeatList ListName{ get{ return Mobiles.FeatList.TirelessRage; } }
		public override FeatCost CostLevel{ get{ return FeatCost.Low; } }
		
		public override SkillName[] AssociatedSkills{ get{ return new SkillName[]{ }; } }
		public override FeatList[] AssociatedFeats{ get{ return new FeatList[]{ }; } }
		
		public override FeatList[] Requires{ get{ return new FeatList[]{ FeatList.DefensiveFury }; } }
		public override FeatList[] Allows{ get{ return new FeatList[]{ }; } }
		
		public override string FirstDescription{ get{ return "Fighting enraged doesn't exhaust you as much. [-1/6 stamina " +
					"penalty when enraged]"; } }
		public override string SecondDescription{ get{ return "[-2/6 stamina penalty when enraged]"; } }
		public override string ThirdDescription{ get{ return "[-3/6 stamina penalty when enraged]"; } }

		public override string FirstCommand{ get{ return "None"; } }
		public override string SecondCommand{ get{ return "None"; } }
		public override string ThirdCommand{ get{ return "None"; } }
		
		public override string FullDescription{ get{ return GetFullDescription(this); } }
		
		public static void Initialize(){ WriteWebpage(new TirelessRage()); }
		
		public TirelessRage() {}
	}
}
