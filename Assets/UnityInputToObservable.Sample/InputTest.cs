using R3;
using UnityEngine;

namespace UnityInputToObservable.Sample
{
    public class InputTest
    { 
        public InputTest(IInputCollectionModel<ActionMapType, ActionType> inputCollectionModel)
        {
            var inputModel = inputCollectionModel[ActionMapType.Player];
            inputModel.SetActionEnabled(ActionType.Move, true);
            inputModel.SetActionEnabled(ActionType.Action, true);
            
            inputModel.GetOnActionPerformed(ActionType.Action)
                .Subscribe(_ => Debug.Log("Input System: Action - performed"));
            
            inputModel.GetOnActionPerformed(ActionType.Move)
                .Subscribe(context => Debug.Log($"Input System, move Value: {context.ReadValue<Vector2>()}"));
        }
        
    }
}