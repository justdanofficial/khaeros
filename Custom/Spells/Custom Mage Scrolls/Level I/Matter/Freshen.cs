﻿using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;
using Server.ContextMenus;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
    public class FreshenScroll : CustomSpellScroll
    {
        public override CustomMageSpell Spell
        {
            get
            {
                return new FreshenSpell();
            }
            set
            {
            }
        }

        [Constructable]
        public FreshenScroll() : base()
        {
            Hue = 2964;
            Name = "A Freshen scroll";
        }

        public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
        {
        }

        public override void OnDoubleClick( Mobile m )
        {
            if( !this.IsChildOf( m.Backpack ) )
                return;

            if( !IsMageCheck( m, true ) )
                return;

            BaseCustomSpell.SpellInitiator( new FreshenSpell( m, 1 ) );
        }

        public FreshenScroll( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int)0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    }

    [PropertyObject]
    public class FreshenSpell : CustomMageSpell
    {
        public override CustomMageSpell GetNewInstance()
        {
            return new FreshenSpell();
        }

        public override bool CustomScripted { get { return true; } }
		public override bool IsMageSpell { get { return true; } }
        public override Type ScrollType { get { return typeof( OrigamiPaper ); } }
		public override bool CanTargetSelf { get { return false; } }
        public override bool AffectsItems { get { return true; } }
		public override bool AffectsMobiles { get { return false; } }
        public override bool IsHarmful { get { return false; } }
        public override bool UsesTarget { get { return true; } }
		public override FeatList Feat{ get{ return FeatList.CustomMageSpell; } }
        public override string Name { get { return "Freshen"; } }
        public override int ManaCost { get { return 10; } }
        public override int BaseRange { get { return 12; } }

        public FreshenSpell()
            : this( null, 1 )
        {
        }

        public FreshenSpell( Mobile caster, int featLevel ) 
            : base( caster, featLevel )
        {
            IconID = 6114;
            Range = 12;
            CustomName = "Freshen";
        }

        public override bool CanBeCast
        {
            get
            {                     
                return base.CanBeCast && HasRequiredArcanas( new FeatList[]{ FeatList.MatterI } );
            }
        }
		
        public override void Effect()
        {		
			if (TargetItem.Parent is Mobile)
			{
				Caster.SendMessage("You cannot use that on an equipped item.");
				Success = false;
				return;
			}
			
			if (TargetItem.IsChildOf( Caster.Backpack ))
			{
				Caster.SendMessage("You cannot use that on an item in your pack.");
				Success = false;
				return;
			}
				
            if( TargetCanBeAffected && CasterHasEnoughMana && TargetItem is Food )
            {
				Food door = TargetItem as Food;
				Caster.Mana -= TotalCost;
				
				if (door.RotStage != RotStage.None)
				{
                Caster.Emote("*Points at the food*");
				door.RotStage = RotStage.None;
				Success = true;
				Timer.DelayCall( TimeSpan.FromSeconds( 1 ), new TimerCallback( Flare ) );
				return;
				}
				
				else
				{
				return;
				}
            }
        }
		
		private void Flare()
		{
			if ( Caster == null )
				return;
				
			if (TargetItem == null || TargetItem.Deleted)
				return;
				
			 TargetItem.PublicOverheadMessage( Network.MessageType.Regular, 0, false, "*Seems to grow fresher...*" );

		}				
	}
}