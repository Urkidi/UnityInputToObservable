using System;
using R3;
using UnityEngine;

namespace UnityInputToObservable.Sample
{
    public class InputTest : IDisposable
    {
        private readonly IDisposable _disposable;

        public InputTest(IInputCollectionModel<ActionMapType, ActionType> inputCollectionModel)
        {
            var builder = Disposable.CreateBuilder();
            var inputModel = inputCollectionModel[ActionMapType.Player];
            
            inputModel.SetActionEnabled(ActionType.Move, true);
            inputModel.SetActionEnabled(ActionType.Action, true);
            
            inputModel.GetOnActionPerformed(ActionType.Action)
                .Subscribe(_ => Debug.Log("Input System: Action - performed"))
                .AddTo(ref builder);
            
            //Adding the merge to GetOnActionCancelled allows us to listen to no input. Resulting in a (0,0) movement update.
            inputModel.GetOnActionPerformed(ActionType.Move)
                .Merge(inputModel.GetOnActionCancelled(ActionType.Move))
                .Subscribe(context => Debug.Log($"Input System, move Value: {context.ReadValue<Vector2>()}"))
                .AddTo(ref builder);
            
            _disposable = builder.Build();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}