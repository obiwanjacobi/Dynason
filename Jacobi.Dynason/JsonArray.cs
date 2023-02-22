using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using DotNet = System.Text.Json;

namespace Jacobi.Dynason
{
    public sealed class JsonArray : JsonElement, IEnumerable<JsonElement>
    {
        internal JsonArray(ref DotNet.JsonElement element)
            : base(ref element)
        { }

        public override JsonElementType Type => JsonElementType.JsonArray;

        public int Length => Element.GetArrayLength();

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object? result)
        {
            if (indexes.Length != 1 || indexes[0] is not int)
            {
                throw new NotSupportedException("Only one integer index at a time is supported.");
            }
            
            var len = Element.GetArrayLength();
            var index = (int)indexes[0];
            
            if (index < 0 || index >= len)
            {
                result = new JsonNull();
            }
            else
            { 
                result = JsonElement.Create(Element[index]);
            }

            return true;
        }

        public IEnumerator<JsonElement> GetEnumerator()
        {
            foreach (var element in Element.EnumerateArray())
            {
                yield return JsonElement.Create(element);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
