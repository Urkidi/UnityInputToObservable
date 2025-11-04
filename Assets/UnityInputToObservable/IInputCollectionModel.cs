using UnityInputToObservable.Enums;

namespace UnityInputToObservable
{
    public interface IInputCollectionModel
    {
        IInputModel this[ActionMapType type] { get; }
    }
}