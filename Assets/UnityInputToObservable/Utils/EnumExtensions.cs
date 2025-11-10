namespace UnityInputToObservable.Utils
{
    public static class EnumExtensions
    {
        public static string GetStringRepresentation<T>(this T value) where T : struct
        {
            InputItemStringRepresentationAttribute[] attributes = (InputItemStringRepresentationAttribute[])value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(InputItemStringRepresentationAttribute), false);
            return attributes.Length > 0? attributes[0].Representation : null;
        }
    }
}