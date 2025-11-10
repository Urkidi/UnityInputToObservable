namespace UnityInputToObservable.Utils
{
    public class InputItemStringRepresentationAttribute : System.Attribute
    {
        public string Representation { get; }

        public InputItemStringRepresentationAttribute(string representation)
        {
            Representation = representation;
        }
    }
}