using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityInputToObservable.Configs
{
    [CreateAssetMenu(fileName = "PlayerInputConfig", menuName = "ScriptableObjects/Configs/PlayerInputConfig", order = 1)]
    public  class PlayerInputConfig : ScriptableObject, IPlayerInputConfig
    {
        [SerializeField] private InputActionAsset _playerInputActionAsset;
        
        public InputActionAsset PlayerInputActionAsset => _playerInputActionAsset;
    }
}