namespace Jacobi.Dynason.Tests
{
    public class JsonArrayTests
    {
        [Fact]
        public void NonExistingIndex()
        {
            dynamic doc = JsonDocument.Parse("[]");

            object val = doc[0];
            val.Should().BeOfType<JsonNull>();
        }

        [Fact]
        public void EnumerateItems()
        {
            dynamic doc = JsonDocument.Parse("[\"Hello\",\"World\",\"Answer\",42]");

            int i = 0;
            foreach (JsonElement element in doc)
            {
                element.Should().NotBeNull();
                i++;
            }

            i.Should().Be(4);
        }

        [Fact]
        public void IndexItems()
        {
            dynamic doc = JsonDocument.Parse("[\"Hello\",\"World\",\"Answer\",42]");

            int i = 0;
            JsonElement element = doc[i++];
            element.IsString.Should().BeTrue();
            element = doc[i++];
            element.IsString.Should().BeTrue();
            element = doc[i++];
            element.IsString.Should().BeTrue();
            element = doc[i++];
            element.IsNumber.Should().BeTrue();
            element = doc[i];   // out of bounds
            element.IsNull.Should().BeTrue();
        }
    }
}