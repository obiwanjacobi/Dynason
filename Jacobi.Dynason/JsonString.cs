using System;
using DotNet = System.Text.Json;

namespace Jacobi.Dynason
{
    public sealed class JsonString : JsonElement
    {
        internal JsonString(ref DotNet.JsonElement element)
            : base(ref element)
        { }

        public override JsonElementType Type => JsonElementType.JsonString;

        public Guid AsGuid() => Element.GetGuid();
        public bool TryAsGuid(out Guid guid) => Element.TryGetGuid(out guid);
        
        public DateTime AsDateTime() => Element.GetDateTime();
        public bool TryAsDateTime(DateTime dateTime) => Element.TryGetDateTime(out dateTime);

        public DateTimeOffset AsDateTimeOffset() => Element.GetDateTimeOffset();
        public bool TryAsDateTimeOffset(out DateTimeOffset dateTime) => Element.TryGetDateTimeOffset(out dateTime);

        public string AsString() => Element.GetString() ?? String.Empty;

        public string Value => AsString();
    }
}
