using R3;
using UnityEngine.InputSystem;

namespace UnityInputToObservable.Utils
{
    public static class ActionExtensions
    {
        public static Observable<InputAction.CallbackContext> PerformedToObservable(this InputAction action) =>
            Observable.FromEvent<InputAction.CallbackContext>(
                h => action.performed += h,
                h => action.performed -= h
            );
        
        public static Observable<InputAction.CallbackContext> CancelledToObservable(this InputAction action) =>
            Observable.FromEvent<InputAction.CallbackContext>(
                h => action.canceled += h,
                h => action.canceled -= h
            );
        public static Observable<InputAction.CallbackContext> StartedToObservable(this InputAction action) =>
            Observable.FromEvent<InputAction.CallbackContext>(
                h => action.started += h,
                h => action.started -= h
            );
    }
}