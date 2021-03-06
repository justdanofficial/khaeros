using System;
using Server;
using Server.Items;
using Server.Multis;
using Server.Multis.Deeds;
using Server.Network;
using Server.Mobiles;

namespace Server.Gumps
{
	public class HouseDemolishGump : Gump
	{
		private Mobile m_Mobile;
		private BaseHouse m_House;

		public HouseDemolishGump( Mobile mobile, BaseHouse house ) : base( 110, 100 )
		{
			m_Mobile = mobile;
			m_House = house;

			mobile.CloseGump( typeof( HouseDemolishGump ) );

			Closable = false;

			AddPage( 0 );

			AddBackground( 0, 0, 420, 280, 5054 );

			AddImageTiled( 10, 10, 400, 20, 2624 );
			AddAlphaRegion( 10, 10, 400, 20 );

			AddHtmlLocalized( 10, 10, 400, 20, 1060635, 30720, false, false ); // <CENTER>WARNING</CENTER>

			AddImageTiled( 10, 40, 400, 200, 2624 );
			AddAlphaRegion( 10, 40, 400, 200 );

			AddHtmlLocalized( 10, 40, 400, 200, 1061795, 32512, false, true ); /* You are about to demolish your house.
																				* All items in the house will be destroyed, and you will not be refunded any money.
																				* Once the house is demolished, anyone can attempt to rent it.
																				* This action will not un-condemn any other houses on your account.
																				* Are you sure you wish to continue?
																				*/

			AddImageTiled( 10, 250, 400, 20, 2624 );
			AddAlphaRegion( 10, 250, 400, 20 );

			AddButton( 10, 250, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 40, 250, 170, 20, 1011036, 32767, false, false ); // OKAY

			AddButton( 210, 250, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 240, 250, 170, 20, 1011012, 32767, false, false ); // CANCEL
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			if ( info.ButtonID == 1 && !m_House.Deleted )
			{
				if ( m_House.IsOwner( m_Mobile ) )
				{
					if ( m_House.MovingCrate != null || m_House.InternalizedVendors.Count > 0 )
					{
						return;
					}
					else if( !Guilds.Guild.NewGuildSystem && m_House.FindGuildstone() != null )
					{
						m_Mobile.SendLocalizedMessage( 501389 ); // You cannot redeed a house with a guildstone inside.
						return;
					}
					/*else if ( m_House.PlayerVendors.Count > 0 )
					{
						m_Mobile.SendLocalizedMessage( 503236 ); // You need to collect your vendor's belongings before moving.
						return;
					}*/
					else if ( m_House.HasRentedVendors && m_House.VendorInventories.Count > 0 )
					{
						m_Mobile.SendLocalizedMessage( 1062679 ); // You cannot do that that while you still have contract vendors or unclaimed contract vendor inventory in your house.
						return;
					}
					else if ( m_House.HasRentedVendors )
					{
						m_Mobile.SendLocalizedMessage( 1062680 ); // You cannot do that that while you still have contract vendors in your house.
						return;
					}
					else if ( m_House.VendorInventories.Count > 0 )
					{
						m_Mobile.SendLocalizedMessage( 1062681 ); // You cannot do that that while you still have unclaimed contract vendor inventory in your house.
						return;
					}

					m_Mobile.SendMessage( "You have successfully demolished your house." );

					m_House.RemoveKeys( m_Mobile );
					m_House.Delete();
						
				}
				else
				{
					m_Mobile.SendLocalizedMessage( 501320 ); // Only the house owner may do this.
				}
			}
		}
	}
}
