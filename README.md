# Unity Input To Observable

Transforms Unity's Input System into observable streams using [R3](https://github.com/Cysharp/R3).
- Package `https://github.com/Urkidi/UnityInputToObservable.git?path=/Assets/UnityInputToObservable/`
- Dependency injection subpackage `https://github.com/Urkidi/UnityInputToObservable.git?path=/Assets/UnityInputToObservable.DependencyInjection`
- Sample subpackage `https://github.com/Urkidi/UnityInputToObservable.git?path=/Assets/UnityInputToObservable.Sample`


---

## Requirements
- Unity 6000.2 or later
- [R3](https://github.com/Cysharp/R3) (must be installed manually)
- Optionally supports Dependency Injection

---

## Setup
1. **Install R3** in your project.
2. **Add the package** from [Git](https://github.com/Urkidi/UnityInputToObservable.git?path=/Assets/UnityInputToObservable/):

```https://github.com/Urkidi/UnityInputToObservable.git?path=/Assets/UnityInputToObservable/```



3. **Create two enums** in your project:

```csharp
public enum ActionMapType 
{
    [StringRepresentation("Player")]
    Player
}

public enum ActionType 
{
    [StringRepresentation("Move")]
    Move,
    [StringRepresentation("Action")]
    Action
}
```
4. The enums string representation must match the InputAction.assets map and action entries.
5. **Create a InputActions.asset**. 
6. Populate the asset with your actions.
7. **Create a PlayerInputConfig** and add the InputActions.asset to it..

### Installing into DI:
```csharp
services.AddUnityInputToObservable<ActionMapType, ActionType>();
```

Add to the DI the ```IPlayerInputConfig``` implementation.

## Usage
1. Access IInputCollectionModel where needed.
2. From the collection model access the specific IInputModel by providing the right ActionMapType.
3. Once accessed the model, subscribe to the desired input event.


