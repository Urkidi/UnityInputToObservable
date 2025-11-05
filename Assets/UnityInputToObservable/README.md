Unity Input To Observable

Transforms Unity's Input System into observable streams using [R3](https://github.com/Cysharp/R3).

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
   4. The enums string representation must match the InputAction.assets map and action entries.
```csharp
public enum PlayerType 
{
    [StringRepresentation("Player")]Player
}

public enum ActionType 
{
    [StringRepresentation("Move")]
    Move,
    [StringRepresentation("Action")]
    Action
}
```
4. **Create a InputActions.asset**
   5. Populate the asset with your actions.
5. **Create a PlayerInputConfig** and add the InputActions.asset to it..

Install into DI:
```csharp
services.AddUnityInputToObservable<PlayerType, ActionType>();
```

You should also to the DI the ```IPlayerInputConfig```


## Extras

 - Dependency injection subpackage `https://github.com/Urkidi/UnityInputToObservable.git?path=/Assets/UnityInputToObservable.DependencyInjection`
 - Sample subpackage `https://github.com/Urkidi/UnityInputToObservable.git?path=/Assets/UnityInputToObservable.Sample`
