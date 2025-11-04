namespace UnityInputToObservable.Utils
{
    public class StringRepresentationAttribute : System.Attribute
    {
        public string Representation;

        public StringRepresentationAttribute(string representation)
        {
            Representation = representation;
        }
    }
}