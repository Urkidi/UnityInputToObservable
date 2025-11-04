using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityInputToObservable
{
    public class InputCollectionModel<TActionMap, TActionType> : IInputCollectionModel<TActionMap, TActionType>
        where TActionMap : struct
        where TActionType : struct
    {
        private readonly Dictionary<TActionMap, IInputModel<TActionMap,TActionType>> _inputModels;
        
        public IInputModel<TActionMap,TActionType> this[TActionMap type] => _inputModels[type];

         public InputCollectionModel(IInputModelFactory inputModelFactory)
         {
             _inputModels = ((TActionMap[])Enum.GetValues(typeof (TActionMap)))
                 .ToDictionary(key => key, inputModelFactory.Create<TActionMap,TActionType>);
         }
    }
}