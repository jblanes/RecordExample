namespace BC.RecordUseExample.Backend.Domain.Validation
{
    public static class Validate
    {
        public static T Value<T>(T value) => value;

        public static string Where<T>(this T value, Func<T, bool> condition, string message)
        {
            if (condition(value))
            {
                return message;
            }
            else
            {
                return string.Empty;
            }
        }


    }
}
