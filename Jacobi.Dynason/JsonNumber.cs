using DotNet = System.Text.Json;

namespace Jacobi.Dynason
{
    public sealed class JsonNumber : JsonElement
    {
        internal JsonNumber(ref DotNet.JsonElement element)
            : base(ref element)
        { }

        public override JsonElementType Type => JsonElementType.JsonNumber;

        public byte AsByte() => Element.GetByte();
        public bool TryAsByte(out byte value) => Element.TryGetByte(out value);
        public ushort AsUShort() => Element.GetUInt16();
        public bool TryAsUShort(out ushort value) => Element.TryGetUInt16(out value);
        public uint AsUInt() => Element.GetUInt32();
        public bool TryAsUInt(out uint value) => Element.TryGetUInt32(out value);
        public ulong AsULong() => Element.GetUInt64();
        public bool TryAsULong(out ulong value) => Element.TryGetUInt64(out value);

        public sbyte AsSByte() => Element.GetSByte();
        public bool TryAsSByte(out sbyte value) => Element.TryGetSByte(out value);
        public short AsShort() => Element.GetInt16();
        public bool TryAsShort(out short value) => Element.TryGetInt16(out value);
        public int AsInt() => Element.GetInt32();
        public bool TryAsInt(out int value) => Element.TryGetInt32(out value);
        public long AsLong() => Element.GetInt64();
        public bool TryAsLong(out long value) => Element.TryGetInt64(out value);

        public float AsFloat() => Element.GetSingle();
        public bool TryAsFloat(out float value) => Element.TryGetSingle(out value);
        public double AsDouble() => Element.GetDouble();
        public bool TryAsDouble(out double value) => Element.TryGetDouble(out value);
        public decimal AsDecimal() => Element.GetDecimal();
        public bool TryAsDecimal(out decimal value) => Element.TryGetDecimal(out value);

        public int Value => AsInt();
    }
}
