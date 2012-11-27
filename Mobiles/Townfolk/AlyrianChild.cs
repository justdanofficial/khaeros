using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles
{
	public class AlyrianChild : BaseKhaerosMobile, IAlyrian
	{
		[Constructable]
		public AlyrianChild() : base( Nation.Alyrian ) 
		{			
			if ( this.Female = Utility.RandomBool() ) 
			{ 
				this.Body = 920; 
				this.Name = RandomName( Nation.Alyrian, true );
			} 
			
			else 
			{ 
				this.Body = 763; 
				this.Name = BaseKhaerosMobile.RandomName( Nation.Alyrian, false );
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

		public AlyrianChild(Serial serial) : base(serial)
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
