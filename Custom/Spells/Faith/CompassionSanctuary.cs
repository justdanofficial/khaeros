﻿using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Commands;
using Server.Targeting;
using Server.Network;
using Server.Regions;

namespace Server.Misc
{
    public class CompassionSanctuary : BaseCustomSpell
    {
        public override bool UsesFullEffect{ get{ return true; } }
		public override FeatList Feat{ get{ return FeatList.Compassion; } }
		public override string Name{ get{ return "Compassion Sanctuary"; } }
		public override int BaseCost{ get{ return 20; } }
		public override double FullEffect{ get{ return (Caster.Skills[SkillName.Faith].Base * 0.20); } }

        public CompassionSanctuary(Mobile caster, int featLevel)
            : base(caster, featLevel)
		{
		}
		
		public override void Effect()
		{
			if( CasterHasEnoughMana )
			{
				Caster.Mana -= TotalCost;
				FinalEffect( Caster, TotalEffect );
				Success = true;
			}
		}
		
		public static void FinalEffect( Mobile target, int duration )
		{
			SanctuaryAddon sanctuary = new SanctuaryAddon();
			sanctuary.Region = new SanctuaryRegion( target, new Rectangle3D( new Point3D( target.X - 4, target.Y - 4, target.Z ), new Point3D( target.X + 6, target.Y + 6, target.Z + 60 ) ) );
			sanctuary.Region.Register();
			sanctuary.MoveToWorld( target.Location );
			sanctuary.Map = target.Map;
			((IKhaerosMobile)target).Sanctuary = new SanctuaryTimer( target, sanctuary, duration );
			((IKhaerosMobile)target).Sanctuary.Start();
			target.PlaySound( 502 );
		}
		
		public static void Initialize()
		{
            CommandSystem.Register("CompassionSanctuary", AccessLevel.Player, new CommandEventHandler(CompassionSanctuary_OnCommand));
		}

        [Usage("CompassionSanctuary")]
        [Description( "Creates a sanctuary for you and your allies." )]
        private static void CompassionSanctuary_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile != null)
            {
                if (e.Mobile is PlayerMobile && ((PlayerMobile)e.Mobile).Feats.GetFeatLevel(FeatList.Compassion) < 1)
                {
                    e.Mobile.SendMessage("You lack the compassion for this feat.");
                    return;
                }
                SpellInitiator(new CompassionSanctuary(e.Mobile, GetSpellPower(e.ArgString, ((IKhaerosMobile)e.Mobile).Feats.GetFeatLevel(FeatList.Compassion))));
            }
        }
        
        public class SanctuaryTimer : Timer
        {
            private Mobile m;
            private SanctuaryAddon addon;

            public SanctuaryTimer( Mobile from, SanctuaryAddon sanct, int delay )
            	: base( TimeSpan.FromSeconds( delay ) )
            {
                m = from;
                addon = sanct;
            }

            protected override void OnTick()
            {
            	if( addon != null )
            		addon.Delete();
            	
            	if( m != null )
            		((IKhaerosMobile)m).Sanctuary = null;
            }
        }
    }
}
