using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles
{
	public class NorthernChild : BaseKhaerosMobile, INorthern
	{
		[Constructable]
		public NorthernChild() : base( Nation.Northern ) 
		{			
			if ( this.Female = Utility.RandomBool() ) 
			{ 
				this.Body = 920; 
				this.Name = RandomName( Nation.Northern, true );
			} 
			
			else 
			{ 
				this.Body = 763; 
				this.Name = BaseKhaerosMobile.RandomName( Nation.Northern, false );
			} 
			
			SetStr( 5 );
			SetDex( 5 );
			SetInt( 5 );
			SetHits( 5 );

			SetDamage( 1, 2 );
			Fame = 10;
			Blessed = true;
			Hue = 0;
		}

		public NorthernChild(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
