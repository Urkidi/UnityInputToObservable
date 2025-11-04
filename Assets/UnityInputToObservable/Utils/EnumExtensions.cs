namespace UnityInputToObservable.Utils
{
    public static class EnumExtensions
    {
        public static string GetStringRepresentation<T>(this T value) where T : struct
        {
            StringRepresentationAttribute[] attributes = (StringRepresentationAttribute[])value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(StringRepresentationAttribute), false);
            return attributes.Length > 0? attributes[0].Representation : null;
        }
    }
}