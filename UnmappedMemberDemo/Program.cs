using System.Text.Json;
using System.Text.Json.Serialization;

string json = """{}""";

MyPoco? result = JsonSerializer.Deserialize(json, MyContext.Default.MyPoco);
Console.WriteLine(result);


record MyPoco
{
    public required int Id { get; init; }
}

[JsonSerializable(typeof(MyPoco))]
partial class MyContext : JsonSerializerContext {}