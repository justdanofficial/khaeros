using System;
using Server;
using System.IO;
using System.Text;
using Server.Network;
using Server.Mobiles;

namespace Server.FeatInfo
{
	public class BruteStrength : BaseFeat
	{
		public override string Name{ get{ return "Brute Strength"; } }
		public override FeatList ListName{ get{ return Mobiles.FeatList.BruteStrength; } }
		public override FeatCost CostLevel{ get{ return FeatCost.High; } }
		
		public override SkillName[] AssociatedSkills{ get{ return new SkillName[]{ }; } }
		public override FeatList[] AssociatedFeats{ get{ return new FeatList[]{ }; } }
		
		public override FeatList[] Requires{ get{ return new FeatList[]{ FeatList.Anatomy }; } }
		public override FeatList[] Allows{ get{ return new FeatList[]{ FeatList.Cleave }; } }
		
		public override string FirstDescription{ get{ return "Having conditioned yourself to rigorous strength training, you are now " +
					"able to wield your weapons with greater force. [+3 base damage]"; } }
		public override string SecondDescription{ get{ return "[+6 base damage]"; } }
		public override string ThirdDescription{ get{ return "[+9 base damage]"; } }

		public override string FirstCommand{ get{ return "None"; } }
		public override string SecondCommand{ get{ return "None"; } }
		public override string ThirdCommand{ get{ return "None"; } }
		
		public override string FullDescription{ get{ return GetFullDescription(this); } }
		
		public static void Initialize(){ WriteWebpage(new BruteStrength()); }
		
		public BruteStrength() {}
	}
}
