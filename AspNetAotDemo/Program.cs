using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.WriteIndented = true;
    // options.SerializerOptions.TypeInfoResolver = TodosContext.Default;
});

WebApplication app = builder.Build();
app.MapGet("/todos", () => GetValues());
app.Run();

static async IAsyncEnumerable<Todo> GetValues()
{
    for (int i = 0; i < 10; i++)
    {
        yield return Random.Shared.NextTodo();
        await Task.Delay(300);
    }
}

public record Todo
{
    public required string Title { get; init; }
    public required Status Status { get; init; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status { NotStarted, InProgress, Done }

// [JsonSerializable(typeof(IAsyncEnumerable<Todo>))]
// public partial class TodosContext : JsonSerializerContext { }