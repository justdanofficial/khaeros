using Khaeros.Scripts.Khaeros.Custom.Vhaerun_s_CRL_Homestead.Vhaerun_s_CRL_Cooking.Base_Cooking;

namespace Server.Items
{
    public class BagOfRicemeal : ItemWithMultipleUses
	{

		[Constructable]
		public BagOfRicemeal() : base( 0x1039 )
		{
			Weight = 5.0;
			Stackable = false;
			Hue = 0x303;
			Name = "Bag of Ricemeal";
		}

		public BagOfRicemeal( Serial serial ) : base( serial )
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

            if( Amount > 1 )
                Amount = 1;
		}
	}
}
