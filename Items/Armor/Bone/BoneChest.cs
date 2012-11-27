using System;
using Server.Items;

namespace Server.Items
{
    public interface IBoneArmour
    {
    }

    [FlipableAttribute(0x144f, 0x1454)]
    public class MhordulBoneChest : BaseArmor, IBoneArmour
    {
        public override int BaseBluntResistance { get { return 16; } }
        public override int BasePiercingResistance { get { return 12; } }
        public override int BaseSlashingResistance { get { return 15; } }
        public override int BasePhysicalResistance { get { return 0; } }
        public override int BaseFireResistance { get { return 3; } }
        public override int BaseColdResistance { get { return 4; } }
        public override int BasePoisonResistance { get { return 0; } }
        public override int BaseEnergyResistance { get { return 0; } }

        public override int InitMinHits { get { return 25; } }
        public override int InitMaxHits { get { return 30; } }

        public override int AosStrReq { get { return 60; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -6; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 11; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public MhordulBoneChest()
            : base(0x144F)
        {
            Weight = 6.0;
            Name = "Mhordul Bone Chest";
        }

        public MhordulBoneChest(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);

            if (Weight == 1.0)
                Weight = 6.0;
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
