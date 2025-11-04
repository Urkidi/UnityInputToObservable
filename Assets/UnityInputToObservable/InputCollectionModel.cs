using System;
using System.Collections.Generic;
using System.Linq;
using UnityInputToObservable.Enums;

namespace UnityInputToObservable
{
    public class InputCollectionModel : IInputCollectionModel
    {
        private readonly Dictionary<ActionMapType, IInputModel> _inputModels;
        
        public IInputModel this[ActionMapType type] => _inputModels[type];

         public InputCollectionModel(IInputModelFactory inputModelFactory)
         {
             _inputModels = ((ActionMapType[])Enum.GetValues(typeof (ActionMapType)))
                 .ToDictionary(key => key, inputModelFactory.Create);
         }
    }
}