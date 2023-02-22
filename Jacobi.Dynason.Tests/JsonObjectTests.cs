namespace Jacobi.Dynason.Tests
{
    public class JsonObjectTests
    {
        [Fact]
        public void NonExistingFields()
        {
            dynamic doc = JsonDocument.Parse("{}");

            object val = doc.Field1.Field2.Value;
            val.Should().BeOfType<JsonNull>();
        }

        [Fact]
        public void NavigateFields()
        {
            dynamic doc = JsonDocument.Parse("{\"Field1\":{\"Field2\":42}}");
            
            int val = doc.Field1.Field2.Value;
            val.Should().Be(42);
        }

        [Fact]
        public void EnumerateFields()
        {
            dynamic doc = JsonDocument.Parse("{\"Field1\":\"Hello\",\"Field2\":42}");

            int i = 1;
            foreach (KeyValuePair<string, JsonElement> pair in doc)
            {
                pair.Key.Should().Be($"Field{i}");
                pair.Value.Should().NotBeNull();
                i++;
            }
        }

        [Fact]
        public void BooleanField()
        {
            dynamic doc = JsonDocument.Parse("{\"Field1\": true, \"Field2\": false}");

            bool val = doc.Field1.Value;
            val.Should().BeTrue();

            val = doc.Field2.Value;
            val.Should().BeFalse();
        }

        [Fact]
        public void NumberField_Float()
        {
            dynamic doc = JsonDocument.Parse("{\"Field1\": 42.42}");

            float val = doc.Field1.AsFloat();
            val.Should().Be(42.42f);

            JsonNumber num = doc.Field1;
            num.AsFloat().Should().Be(42.42f);
            num.AsDouble().Should().Be(42.42d);
            num.AsDecimal().Should().Be(42.42M);
        }

        [Fact]
        public void NumberField_Int()
        {
            dynamic doc = JsonDocument.Parse("{\"Field1\": 42}");

            int val = doc.Field1.AsInt();
            val.Should().Be(42);

            JsonNumber num = doc.Field1;
            num.AsSByte().Should().Be(42);
            num.AsShort().Should().Be(42);
            num.AsInt().Should().Be(42);
            num.AsLong().Should().Be(42);

            num.AsByte().Should().Be((Byte)42);
            num.AsUShort().Should().Be((UInt16)42);
            num.AsUInt().Should().Be((UInt32)42);
            num.AsULong().Should().Be((UInt64)42);
        }

        [Fact]
        public void StringField()
        {
            dynamic doc = JsonDocument.Parse("{\"Field1\": \"Hello\"}");

            string val = doc.Field1.Value;
            val.Should().Be("Hello");
        }

        [Fact]
        public void StringGuidField()
        {
            var guid = Guid.NewGuid();
            dynamic doc = JsonDocument.Parse("{\"Field1\": \"" + guid.ToString() + "\"}");

            Guid val = doc.Field1.AsGuid();
            val.Should().Be(guid);
        }

        [Fact]
        public void StringDateTimeField()
        {
            var date = new DateTime(2023, 02, 28, 23, 56, 42);
            dynamic doc = JsonDocument.Parse("{\"Field1\": \"" + date.ToString("s") + "\"}");

            DateTime val = doc.Field1.AsDateTime();
            val.Should().Be(date);
        }

        [Fact]
        public void StringDateTimeOffsetField()
        {
            var date = new DateTimeOffset(2023, 02, 28, 23, 56, 42, TimeSpan.FromHours(1));
            dynamic doc = JsonDocument.Parse("{\"Field1\": \"" + date.ToString("s") + "\"}");

            DateTimeOffset val = doc.Field1.AsDateTime();
            val.Should().Be(date);
        }
    }
}