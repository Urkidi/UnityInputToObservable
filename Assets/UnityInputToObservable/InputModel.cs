using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using R3;
using UnityEngine.InputSystem;
using UnityInputToObservable.Configs;
using UnityInputToObservable.Enums;
using UnityInputToObservable.Utils;

namespace UnityInputToObservable
{
    public interface IInputModelFactory
    {
        public IInputModel Create(ActionMapType mapType);
    }
    
    public class InputModel : IInputModel
    {
        private readonly Dictionary<string, ActionType> _dictionary;
    
        public ActionMapType MapType { get; }
    
        private readonly InputActionMap _mapAsset;
    
        private Dictionary<ActionType, Observable<InputAction.CallbackContext>> _actionStartedDictionary = new();
        private Dictionary<ActionType, Observable<InputAction.CallbackContext>> _actionCancelledDictionary = new();
        private Dictionary<ActionType, Observable<InputAction.CallbackContext>> _actionPerformedDictionary = new();
    
        public InputModel(ActionMapType mapType, IPlayerInputConfig config)
        {
            _dictionary = ((ActionType[])System.Enum.GetValues(typeof(ActionType)))
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
            ActionType actionType)
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
    
        public void SetActionEnabled(ActionType actionType, bool enabled)
        {
            if (enabled)
                _mapAsset.FindAction(actionType.GetStringRepresentation()).Enable();
            else
                _mapAsset.FindAction(actionType.GetStringRepresentation()).Disable();
        }
    
        public Observable<InputAction.CallbackContext> GetOnActionStarted(ActionType type)
        {
            return _actionStartedDictionary[type];
        }
    
        public Observable<InputAction.CallbackContext> GetOnActionCancelled(ActionType type)
        {
            return _actionCancelledDictionary[type];
        }
    
        public Observable<InputAction.CallbackContext> GetOnActionPerformed(ActionType type)
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