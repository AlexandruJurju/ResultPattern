namespace ResultPattern.Errors;

public static class TestErrors
{
    public static Error NotFound(int id) => new Error(
        "Test.NotFound",
        $"The entry with id {id} was not found.");
}