using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Multis;

namespace Server.Items
{
	public class NorthernMercenaryContract : Item
	{
		public override string DefaultName
		{
			get { return "an Northern mercenary contract"; }
		}

		[Constructable]
		public NorthernMercenaryContract() : base( 0x14F0 )
		{
			Weight = 1.0;
		}

		public NorthernMercenaryContract( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int)0 ); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
			
			else if ( from.Alive )
			{
				NorthernMercenary v = new NorthernMercenary();

				v.Direction = from.Direction & Direction.Mask;
				v.MoveToWorld( from.Location, from.Map );
				v.Owner = from;
				v.ControlMaster = from;
				v.Controlled = true;

				this.Delete();
			}
		}
	}
}
