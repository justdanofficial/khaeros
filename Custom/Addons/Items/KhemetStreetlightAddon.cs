/////////////////////////////////////////////////
//                                             //
// Automatically generated by the              //
// AddonGenerator script by Arya               //
//                                             //
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class KhemetStreetlight : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new KhemetStreetlightDeed();
			}
		}

		[ Constructable ]
		public KhemetStreetlight()
		{
			AddonComponent ac;
			ac = new AddonComponent( 6570 );
			ac.Light = LightType.Circle225;
			ac.Hue = 1309;
			ac.Name = "Brazier";
			AddComponent( ac, 0, 0, 0 );
			ac = new AddonComponent( 6477 );
			ac.Light = LightType.Circle225;
			ac.Name = "Brazier";
			AddComponent( ac, 0, 0, 13 );

		}

		public KhemetStreetlight( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class KhemetStreetlightDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new KhemetStreetlight();
			}
		}

		[Constructable]
		public KhemetStreetlightDeed()
		{
			Name = "Khemet Streetlight";
		}

		public KhemetStreetlightDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
