namespace ST.Doamin.Commons.Primitives;

public static class ValidationErrors
{
    public static class General
    {
        public static string IsRequired(string propName) => $"The {propName} is required.";
    }
}