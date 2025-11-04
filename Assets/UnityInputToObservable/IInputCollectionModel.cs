using System;

namespace UnityInputToObservable
{
    public interface IInputCollectionModel<TActionMap, in TActionType> 
        where TActionMap : struct
        where TActionType : struct
    {
        IInputModel<TActionMap, TActionType> this[TActionMap type] { get; }
    }
}