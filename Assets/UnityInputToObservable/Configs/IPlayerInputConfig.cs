using UnityEngine.InputSystem;

namespace UnityInputToObservable.Configs
{
    public interface IPlayerInputConfig
    {
        InputActionAsset PlayerInputActionAsset { get; }
    }
}