using System;
using System.Dynamic;
using DotNet = System.Text.Json;

namespace Jacobi.Dynason
{
    public enum JsonElementType
    {
        JsonNull,
        JsonArray,
        JsonObject,
        JsonString,
        JsonNumber,
        JsonBoolean
    }

    public abstract class JsonElement : DynamicObject
    {
        protected readonly DotNet.JsonElement Element;

        protected JsonElement()
            => Element = new DotNet.JsonElement();

        protected JsonElement(ref DotNet.JsonElement element)
            => Element = element;

        public abstract JsonElementType Type { get; }

        public bool IsNull => Type == JsonElementType.JsonNull;
        public bool IsArray => Type == JsonElementType.JsonArray;
        public bool IsObject => Type == JsonElementType.JsonObject;
        public bool IsString => Type == JsonElementType.JsonString;
        public bool IsNumber => Type == JsonElementType.JsonNumber;
        public bool IsBoolean => Type == JsonElementType.JsonBoolean;

        internal static JsonElement Create(DotNet.JsonElement element)
            => element.ValueKind switch
            {
                DotNet.JsonValueKind.Array => new JsonArray(ref element),
                DotNet.JsonValueKind.Object => new JsonObject(ref element),
                DotNet.JsonValueKind.String => new JsonString(ref element),
                DotNet.JsonValueKind.Number => new JsonNumber(ref element),
                DotNet.JsonValueKind.True => new JsonBoolean(ref element),
                DotNet.JsonValueKind.False => new JsonBoolean(ref element),
                DotNet.JsonValueKind.Null => new JsonNull(ref element),
                _ => throw new Exception("Unknown or unsupported JSON node type.")
            };
    }
}