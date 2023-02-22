using System.Dynamic;
using DotNet = System.Text.Json;

namespace Jacobi.Dynason
{
    public sealed class JsonNull : JsonElement
    {
        internal JsonNull()
        { }

        internal JsonNull(ref DotNet.JsonElement element)
            : base(ref element)
        { }

        public override JsonElementType Type => JsonElementType.JsonNull;

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object? result)
        {
            result = new JsonNull();
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            result = new JsonNull();
            return true;
        }
    }
}
