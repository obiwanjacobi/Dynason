namespace Jacobi.Dynason.Tests
{
    public class JsonDocumentTests
    {
        [Fact]
        public void Parse_Number()
        {
            var doc = JsonDocument.Parse("42");
            doc.Should().NotBeNull();
            var root = doc.RootElement;
            root.Should().BeOfType<JsonNumber>();
            var num = (JsonNumber)root;
            num.AsInt().Should().Be(42);
        }

        [Fact]
        public void Parse_String()
        {
            var doc = JsonDocument.Parse("\"NakedString\"");
            doc.Should().NotBeNull();
            var root = doc.RootElement;
            root.Should().BeOfType<JsonString>();
            var str = (JsonString)root;
            str.Value.Should().Be("NakedString");
        }

        [Fact]
        public void Parse_EmptyObject()
        {
            var doc = JsonDocument.Parse("{}");
            doc.Should().NotBeNull();
            var root = doc.RootElement;
            root.Should().BeOfType<JsonObject>();
        }

        [Fact]
        public void Parse_EmptyArray()
        {
            var doc = JsonDocument.Parse("[]");
            doc.Should().NotBeNull();
            var root = doc.RootElement;
            root.Should().BeOfType<JsonArray>();
        }

        [Fact]
        public void DocFields()
        {
            dynamic doc = JsonDocument.Parse("{\"Field1\":\"Value1\"}");

            string val = doc.Field1.Value;
            val.Should().Be("Value1");
        }
    }
}