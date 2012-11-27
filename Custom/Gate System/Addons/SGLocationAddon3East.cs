using System;
using Server;
using Server.Network;
using Server.Items;
using System.Collections;

namespace Server.Items
{
    public class SGLocationAddon3East : BaseAddon
    {
        [Constructable]
        public SGLocationAddon3East ()
        {
            AddComponent(new AddonComponent(2321), 0, 0, 0); 
        }

        public SGLocationAddon3East(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SGLocationLantern3East : AddonComponent
    {
        [Constructable]
        public SGLocationLantern3East() : base(2567)
        {
            Name = "A Torch";
            Light = LightType.Circle225;
        }

        public SGLocationLantern3East(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SGFloorTile3 : AddonComponent
    {
        [Constructable]
        public SGFloorTile3() : base(1314)
        {
            
        }

        public SGFloorTile3(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SGBlockA3 : AddonComponent
    {
        [Constructable]
        public SGBlockA3() : base(1872)
        {
            
        }

        public SGBlockA3(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SGBlockA4 : AddonComponent
    {
        [Constructable]
        public SGBlockA4() : base(1874)
        {
            
        }

        public SGBlockA4(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SGBlockA5 : AddonComponent
    {
        [Constructable]
        public SGBlockA5() : base(1876)
        {
            
        }

        public SGBlockA5(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SGBlockA6 : AddonComponent
    {
        [Constructable]
        public SGBlockA6() : base(1877)
        {
            
        }

        public SGBlockA6(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SGBlockA7 : AddonComponent
    {
        [Constructable]
        public SGBlockA7() : base(114)
        {
            
        }

        public SGBlockA7(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SGBlockA8 : AddonComponent
    {
        [Constructable]
        public SGBlockA8() : base(118)
        {
            
        }

        public SGBlockA8(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SGBlockA9 : AddonComponent
    {
        [Constructable]
        public SGBlockA9() : base(8705)
        {
            
        }

        public SGBlockA9(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SGBlockA10 : AddonComponent
    {
        [Constructable]
        public SGBlockA10() : base(119)
        {
            
        }

        public SGBlockA10(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SGBlockA11 : AddonComponent
    {
        [Constructable]
        public SGBlockA11() : base(8782)
        {
            
        }

        public SGBlockA11(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    
   

}