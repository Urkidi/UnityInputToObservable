using System;
using System.Collections.Generic;
using System.Linq;
using R3;
using UnityEngine.InputSystem;
using UnityInputToObservable.Configs;
using UnityInputToObservable.Utils;

namespace UnityInputToObservable
{
    public interface IInputModelFactory
    {
        public IInputModel<TActionMapType, TActionType> Create<TActionMapType, TActionType>(TActionMapType mapType) 
            where TActionMapType : struct
            where TActionType : struct;
    }
    
    public class InputModel<TActionMapType, TActionType> : IInputModel<TActionMapType, TActionType> 
        where TActionMapType : struct
        where TActionType : struct
    {
        private readonly Dictionary<string, TActionType> _dictionary;
    
        public TActionMapType MapType { get; }
    
        private readonly InputActionMap _mapAsset;
    
        private readonly Dictionary<TActionType, Observable<InputAction.CallbackContext>> _actionStartedDictionary = new();
        private readonly Dictionary<TActionType, Observable<InputAction.CallbackContext>> _actionCancelledDictionary = new();
        private readonly Dictionary<TActionType, Observable<InputAction.CallbackContext>> _actionPerformedDictionary = new();
    
        public InputModel(TActionMapType mapType, IPlayerInputConfig config)
        {
            _dictionary = ((TActionType[])System.Enum.GetValues(typeof(TActionType)))
                .Where(e=> e.GetStringRepresentation()!= null)
                .ToDictionary(e => e.GetStringRepresentation());
            MapType = mapType;
            _mapAsset = config.PlayerInputActionAsset.FindActionMap(MapType.GetStringRepresentation());
    
            SetUpActions();
        }
    
        private void SetUpActions()
        {
            var actions = _mapAsset.actions
                .Where(action => _dictionary.ContainsKey(action.name))
                .Select(action => _dictionary[action.name]);

            foreach (var action in actions)
            {
                _actionCancelledDictionary[action] = CreateSubject(ActionSubjectType.Cancelled, action);
                _actionPerformedDictionary[action] = CreateSubject(ActionSubjectType.Performed, action);
                _actionStartedDictionary[action] = CreateSubject(ActionSubjectType.Started, action);
            }
        }
    
        private Observable<InputAction.CallbackContext> CreateSubject(ActionSubjectType subjectType,
            TActionType actionType)
        {
            switch (subjectType)
            {
                case ActionSubjectType.Started:
                    return _mapAsset.FindAction(actionType.GetStringRepresentation()).StartedToObservable();
                case ActionSubjectType.Performed:
                    return _mapAsset.FindAction(actionType.GetStringRepresentation()).PerformedToObservable();
                case ActionSubjectType.Cancelled:
                    return _mapAsset.FindAction(actionType.GetStringRepresentation()).CancelledToObservable();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    
        public void SetActionEnabled(TActionType actionType, bool enabled)
        {
            if (enabled)
                _mapAsset.FindAction(actionType.GetStringRepresentation()).Enable();
            else
                _mapAsset.FindAction(actionType.GetStringRepresentation()).Disable();
        }
    
        public Observable<InputAction.CallbackContext> GetOnActionStarted(TActionType type)
        {
            return _actionStartedDictionary[type];
        }
    
        public Observable<InputAction.CallbackContext> GetOnActionCancelled(TActionType type)
        {
            return _actionCancelledDictionary[type];
        }
    
        public Observable<InputAction.CallbackContext> GetOnActionPerformed(TActionType type)
        {
            return _actionPerformedDictionary[type];
        }
    
        private enum ActionSubjectType
        {
            Started,
            Cancelled,
            Performed
        }
    }
}