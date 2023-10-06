public static class Helpers
{
    public static Todo NextTodo(this Random random)
    {
        return new Todo
        {
            Title = random.OneOf(
            [
                "Wash the dishes.",
                "Dry the dishes.",
                "Turn the dishes over.",
                "Walk the kangaroo.",
                "Call Grandma."
            ]),

            Status = random.OneOf(Enum.GetValues<Status>()),
        };
    }

    public static T OneOf<T>(this Random random, params T[] values)
        =>  values[random.Next(values.Length)];
}
