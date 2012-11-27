using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class AzhuranHookedClub : BaseBashing
	{
		public override string NameType{ get{ return "Azhuran Hooked Club"; } }
		
		//public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ShadowStrike; } }
		//public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Dismount; } }

		public override int AosStrengthReq{ get{ return 25; } }
		public override double OverheadPercentage{ get{ return 0.4; } }
		public override double SwingPercentage{ get{ return 0.5; } }
		public override double ThrustPercentage{ get{ return 0.1; } }
		public override double RangedPercentage{ get{ return 0; } }
		public override int AosMinDamage{ get{ return 12; } }
		public override int AosMaxDamage{ get{ return 12; } }
		public override double AosSpeed{ get{ return 3; } }

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 8; } }
		public override int OldMaxDamage{ get{ return 24; } }
		public override int OldSpeed{ get{ return 40; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 40; } }

		[Constructable]
		public AzhuranHookedClub() : base( 0x3DEA )
		{
			Weight = 5.0;
			Name = "Azhuran Hooked Club";
			AosElementDamages.Piercing = 50;
			AosElementDamages.Blunt = 50;
		}

		public AzhuranHookedClub( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
