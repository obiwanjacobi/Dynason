using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using DotNet = System.Text.Json;

namespace Jacobi.Dynason
{
    public sealed class JsonObject : JsonElement, IEnumerable<KeyValuePair<string, JsonElement>>
    {
        internal JsonObject(ref DotNet.JsonElement element)
            : base(ref element)
        { }

        public override JsonElementType Type => JsonElementType.JsonObject;

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            if (Element.TryGetProperty(binder.Name, out DotNet.JsonElement element))
            {
                result = JsonElement.Create(element);
            }
            else
            {
                result = new JsonNull();
            }

            return true;
        }

        public IEnumerator<KeyValuePair<string, JsonElement>> GetEnumerator()
        {
            foreach (var property in Element.EnumerateObject())
            {
                yield return KeyValuePair.Create(property.Name, JsonElement.Create(property.Value));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
