using R3;
using UnityEngine.InputSystem;

namespace UnityInputToObservable
{
    public interface IInputModel<out TActionMap, in TActionType>
        where TActionType : struct
        where TActionMap : struct
    {
        TActionMap MapType { get; }
        void SetActionEnabled(TActionType actionType, bool enabled);
        Observable<InputAction.CallbackContext> GetOnActionStarted(TActionType type);
        Observable<InputAction.CallbackContext> GetOnActionCancelled(TActionType type);
        Observable<InputAction.CallbackContext> GetOnActionPerformed(TActionType type);

    }
}