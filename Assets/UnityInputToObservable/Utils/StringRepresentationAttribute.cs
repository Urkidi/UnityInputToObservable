namespace UnityInputToObservable.Utils
{
    public class StringRepresentationAttribute : System.Attribute
    {
        public string Representation { get; }

        public StringRepresentationAttribute(string representation)
        {
            Representation = representation;
        }
    }
}