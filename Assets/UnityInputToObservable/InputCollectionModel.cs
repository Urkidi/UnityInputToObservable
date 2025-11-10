using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityInputToObservable
{
    /// <summary>
    /// Creates an input model per action map.
    /// Even if the action map has no representation the model is created.
    /// The created model will throw if the action map is not supported.
    /// </summary>
    /// <typeparam name="TActionMap"></typeparam>
    /// <typeparam name="TActionType"></typeparam>
    public class InputCollectionModel<TActionMap, TActionType> : IInputCollectionModel<TActionMap, TActionType>
        where TActionMap : struct
        where TActionType : struct
    {
        private readonly Dictionary<TActionMap, IInputModel<TActionMap,TActionType>> _inputModels;
        
        public IInputModel<TActionMap,TActionType> this[TActionMap type] => _inputModels[type];

         public InputCollectionModel(IInputModelFactory<TActionMap, TActionType> inputModelFactory)
         {
             _inputModels = ((TActionMap[])Enum.GetValues(typeof (TActionMap)))
                 .ToDictionary(key => key, inputModelFactory.Create);
         }
    }
}