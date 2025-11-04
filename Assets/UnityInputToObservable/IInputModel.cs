using R3;
using UnityEngine.InputSystem;
using UnityInputToObservable.Enums;

namespace UnityInputToObservable
{
    public interface IInputModel
    {
        ActionMapType MapType { get; }
        void SetActionEnabled(ActionType actionType, bool enabled);
        Observable<InputAction.CallbackContext> GetOnActionStarted(ActionType type);
        Observable<InputAction.CallbackContext> GetOnActionCancelled(ActionType type);
        Observable<InputAction.CallbackContext> GetOnActionPerformed(ActionType type);

    }
}