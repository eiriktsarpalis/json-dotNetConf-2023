using System.Text.Json;
using System.Text.Json.Serialization;

string json = """{ "Values" : [1,2,3], "Nested" : { "Id" : "id" } }""";

MyPoco? result = JsonSerializer.Deserialize(json, MyContext.Default.MyPoco);
Console.WriteLine(result);



class MyPoco
{
    public IList<int> Values { get; } = [];
    public NestedPoco Nested { get; } = new();
}

class NestedPoco
{
    public string? Id { get; set; }
}

[JsonSerializable(typeof(MyPoco))]
partial class MyContext : JsonSerializerContext { }