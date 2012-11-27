using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles
{
	public class TyreanHusky : Dog, ITundraCreature
	{
		public override int[] Hues{ get{ return new int[]{2686,2967,2617}; } }
		
		[Constructable]
		public TyreanHusky() : base()
		{
			NewBreed = "Tyrean Husky";
		}

		public TyreanHusky(Serial serial) : base(serial)
		{
		}
		
		public override void PrepareToGiveBirth()
		{
			GiveBirth( new TyreanHusky() );
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
