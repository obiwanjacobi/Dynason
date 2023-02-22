using DotNet = System.Text.Json;

namespace Jacobi.Dynason
{
    public sealed class JsonBoolean : JsonElement
    {
        internal JsonBoolean(ref DotNet.JsonElement element)
            : base(ref element)
        { }

        public override JsonElementType Type => JsonElementType.JsonBoolean;

        public bool AsBoolean() => Element.GetBoolean();
        public bool Value => AsBoolean();
    }
}
