﻿using System;
using System.IO;
using System.Collections;
using Server;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
    public class BarleySheath : Item
    {
        [Constructable]
        public BarleySheath()
            : this( 1 )
        {
        }

        [Constructable]
        public BarleySheath( int amount )
            : base( 0x1EBD )
        {
            Amount = amount;
            Weight = 3.0;
            Stackable = true;
            Name = "Barley Sheath";
        }

        public BarleySheath( Serial serial )
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

        public override void OnDoubleClick( Mobile from )
        {
            if( !Movable )
                return;

            from.Target = new InternalTarget( this );
        }

        private class InternalTarget : Target
        {
            private BarleySheath m_Item;

            public InternalTarget( BarleySheath item )
                : base( 1, false, TargetFlags.None )
            {
                m_Item = item;
            }

            protected override void OnTarget( Mobile from, object targeted )
            {
                if( m_Item.Deleted ) return;

                else if( IsFlourMill( targeted ) )
                {
                    if( m_Item.Amount >= 8 )
                    {
                        m_Item.Consume( 8 );
                        from.SendMessage( "You made a bag of Barley" );
                        from.AddToBackpack( new BagOfBarley() );
                    }
                    else
                        from.SendMessage( "You don't have enough Barley." );
                }
            }
        }

        public static bool IsFlourMill( object targeted )
        {
            int itemID;

            if( targeted is Item )
                itemID = ( (Item)targeted ).ItemID & 0x3FFF;
            else if( targeted is StaticTarget )
                itemID = ( (StaticTarget)targeted ).ItemID & 0x3FFF;
            else
                return false;

            if( itemID >= 0x1883 && itemID <= 0x1893 )
                return true; // millstones
            else if( itemID >= 0x1920 && itemID <= 0x1937 )
                return true; // flourmill

            return false;
        }
    }
}
