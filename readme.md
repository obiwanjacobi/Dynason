# Dynason

A dynamic Json library that allows (read-only) discovery of a Json document using late binding.

## Usage

The `using` statement:

```csharp
using Jacobi.Dynason;
```

Examples:

```json
{
	"Field1": {
		"Field2": "Hello"
	}
}
```

```csharp
// load a json file
dynamic doc = JsonDocument.Open("data.json");

// navigate structure using the property names.
// use 'JsonElement' as a base type.
JSonElement element = doc.Field1.Field2;

// test what kind of Json element this is.
if (element.IsString)
{
	var typed = (JsonString)element;
	// various (Try)AsXxxx methods are available.
	var str = typed.AsString()
	// str = 'Hello'

	// JsonString and JsonNumber have a Value property
	var val = type.Value;
	// val = 'Hello'
}

// shorter: dynamically call 'Value'
string val = doc.Field1.Field2.Value;
// val = 'Hello'
```

Iterating over Array items or Object properties:

```json
{
	"Field1": [
		"Hello", "World"
	]
}
```

```csharp
// there is also a Parse method
dynamic doc = JsonDocument.Parse(...);
JSonArray array = doc.Field1;

// use a concrete type for the item variable.
foreach (JsonString item in array)
{
	Console.WriteLine(item.Value);
}
// Hello
// World
```

What happens when the properties don't exist?

```csharp
// empty json document
dynamic doc = JsonDocument.Parse("{}");

// no exceptions are throw on navigating non-existent properties.
JsonElement element = doc.Field1.Field2;

// JsonNull is the return type.
if (!element.IsNull)
{ /* never gets here */}
```

---

## Tips

- Use `dynamic` type when you want to navigate over the Json structure.
- Avoid using `var` for variables. Instead use the concrete types.
- Use `object` when you're not sure what type to expect (and it should not be `dynamic`).

---

## todo

- Add Json parsing options to `Open` and `Parse`.
