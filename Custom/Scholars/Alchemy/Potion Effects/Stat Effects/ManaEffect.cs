using System;
using Server;

namespace Server.Items
{
	public class ManaEffect : CustomPotionEffect
	{
		public override string Name{ get{ return "Mana"; } }
		private const double Divisor = 0.20; // 20 stat bonus and 5 minute duration at 100 intensity

		public override void ApplyEffect( Mobile to, Mobile source, int intensity, Item itemSource )
		{
			bool curse = false;
			if ( intensity < 0 )
			{
				if ( source != to )
					source.DoHarmful( to );

				curse = true;
				intensity*=-1;
			}

			int offset = (int)( intensity * Divisor );
			TimeSpan duration = TimeSpan.FromSeconds( (int)( (intensity * 15) * Divisor ) );
			if ( !Spells.SpellHelper.AddStatOffset( to, StatType.ManaMax, ( curse ? -1 : 1 ) * ( BasePotion.Scale( to, offset ) ), duration ) )
				to.SendLocalizedMessage( 502173 ); // You are already under a similar effect.
		}

		public override bool CanDrink( Mobile mobile )
		{
			return true;
		}

		public override void OnExplode( Mobile source, Item itemSource, int intensity, Point3D loc, Map map )
		{
		}
	}
}
