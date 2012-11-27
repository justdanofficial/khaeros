using System;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x2B79, 0x3170)]
    public class HideFemaleChest : BaseArmor
    {
        public override ArmourWeight ArmourType { get { return ArmourWeight.Medium; } }

        public override int BaseBluntResistance { get { return 9; } }
        public override int BaseSlashingResistance { get { return 6; } }
        public override int BasePiercingResistance { get { return 3; } }
        public override int BasePhysicalResistance { get { return 0; } }
        public override int BaseFireResistance { get { return 3; } }
        public override int BaseColdResistance { get { return 4; } }
        public override int BasePoisonResistance { get { return 0; } }
        public override int BaseEnergyResistance { get { return 0; } }

        public override int InitMinHits { get { return 35; } }
        public override int InitMaxHits { get { return 45; } }

        public override int AosStrReq { get { return 35; } }
        public override int OldStrReq { get { return 35; } }

        public override int ArmorBase { get { return 15; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        public override ArmorMeditationAllowance DefMedAllowance { get { return ArmorMeditationAllowance.Half; } }

        public override bool AllowMaleWearer { get { return false; } }

        [Constructable]
        public HideFemaleChest()
            : base(0x2B79)
        {
            Weight = 6.0;
        }

        public HideFemaleChest(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}
