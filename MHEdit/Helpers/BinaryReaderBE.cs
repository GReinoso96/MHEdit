using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.Helpers
{
    internal class BinaryReaderBE : BinaryReader
    {
        private bool endianness;
        public BinaryReaderBE(Stream stream, bool endian) : base(stream) { endianness = endian; }

        public override Int32 ReadInt32()
        {
            if (endianness)
            {
                return ReadInt32BE();
            }
            return base.ReadInt32();
        }

        public override UInt32 ReadUInt32()
        {
            if (endianness)
            {
                return ReadUInt32BE();
            }
            return base.ReadUInt32();
        }
        public override Int16 ReadInt16()
        {
            if (endianness)
            {
                return ReadInt16BE();
            }
            return base.ReadInt16();
        }

        public override UInt16 ReadUInt16()
        {
            if (endianness)
            {
                return ReadUInt16BE();
            }
            return base.ReadUInt16();
        }

        public int ReadInt32BE()
        {
            var data = base.ReadBytes(4);
            Array.Reverse(data);
            return BitConverter.ToInt32(data, 0);
        }

        public UInt32 ReadUInt32BE()
        {
            var data = base.ReadBytes(4);
            Array.Reverse(data);
            return BitConverter.ToUInt32(data, 0);
        }

        public Int16 ReadInt16BE()
        {
            var data = base.ReadBytes(2);
            Array.Reverse(data);
            return BitConverter.ToInt16(data, 0);
        }

        public UInt16 ReadUInt16BE()
        {
            var data = base.ReadBytes(2);
            Array.Reverse(data);
            return BitConverter.ToUInt16(data, 0);
        }

        public Int64 ReadInt64BE()
        {
            var data = base.ReadBytes(8);
            Array.Reverse(data);
            return BitConverter.ToInt64(data, 0);
        }
    }
    internal class BinaryWriterBE : BinaryWriter
    {
        private bool endianness;
        public BinaryWriterBE(Stream stream, bool endian) : base(stream) { endianness = endian; }

        public override void Write(UInt16 value)
        {
            if (endianness)
            {
                WriteBE(value);
            }
            else
            {
                base.Write(value);
            }
        }
        public override void Write(UInt32 value)
        {
            if (endianness)
            {
                WriteBE(value);
            }
            else
            {
                base.Write(value);
            }
        }

        public override void Write(Int16 value)
        {
            if (endianness)
            {
                WriteBE(value);
            }
            else
            {
                base.Write(value);
            }
        }
        public override void Write(Int32 value)
        {
            if (endianness)
            {
                WriteBE(value);
            }
            else
            {
                base.Write(value);
            }
        }

        public void WriteBE(UInt16 value)
        {
            var data = BitConverter.GetBytes(value);
            Array.Reverse(data);
            OutStream.Write(data, 0, 2);
        }
        public void WriteBE(UInt32 value)
        {
            var data = BitConverter.GetBytes(value);
            Array.Reverse(data);
            OutStream.Write(data, 0, 4);
        }
        public void WriteBE(Int16 value)
        {
            var data = BitConverter.GetBytes(value);
            Array.Reverse(data);
            OutStream.Write(data, 0, 2);
        }
        public void WriteBE(Int32 value)
        {
            var data = BitConverter.GetBytes(value);
            Array.Reverse(data);
            OutStream.Write(data, 0, 4);
        }
    }
}
