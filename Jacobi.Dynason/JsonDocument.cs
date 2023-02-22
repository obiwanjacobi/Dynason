using System.Collections;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;
using DotNet = System.Text.Json;

namespace Jacobi.Dynason
{
    public sealed class JsonDocument : DynamicObject, IEnumerable
    {
        private readonly DotNet.JsonDocument _document;

        private JsonDocument(DotNet.JsonDocument document)
            => _document = document;

        private JsonElement? _root;
        public JsonElement RootElement 
            => _root ??= JsonElement.Create(_document.RootElement)!;

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
            => RootElement.TryGetMember(binder, out result);

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object? result)
            => RootElement.TryGetIndex(binder, indexes, out result);

        public static JsonDocument Open(string file)
        {
            using var stream = File.Open(file, FileMode.Open);
            return Parse(stream);
        }
        public static Task<JsonDocument> OpenAsync(string file)
        {
            using var stream = File.Open(file, FileMode.Open);
            return ParseAsync(stream);
        }

        public static JsonDocument Parse(string json)
            => new(DotNet.JsonDocument.Parse(json));
        public static JsonDocument Parse(Stream json)
            => new(DotNet.JsonDocument.Parse(json));
        public static async Task<JsonDocument> ParseAsync(Stream json)
            => new(await DotNet.JsonDocument.ParseAsync(json));

        public IEnumerator GetEnumerator()
        {
            if (RootElement.IsArray)
                return ((JsonArray)RootElement).GetEnumerator();

            if (RootElement.IsObject)
                return ((JsonObject)RootElement).GetEnumerator();

            return GetEmptyEnumerator();
        }

        private static IEnumerator GetEmptyEnumerator()
        {
            yield break;
        }
    }
}