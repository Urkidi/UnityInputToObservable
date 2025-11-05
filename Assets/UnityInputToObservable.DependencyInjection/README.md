Unity Input To Observable Dependency Injection support

---

## Requirements
- Unity 6000.2 or later
- [R3](https://github.com/Cysharp/R3) (must be installed manually)
- Microsoft.Extensions.DependencyInjection.Abstractions (must be installed Via NuGet  for Unity)
- UnityInputToObservable package

---

## Setup
1. Create an enum for ActionMap and ActionType if you haven't already.
2. Call from your IServiceCollection to the extension method `InstallUnityInputToObservablePackage`.
3. When calling the method use your ActionMap enum as TActionMap and ActionType enum as TActionType.
4. Inject IInputCollectionModel when needed.
5. From the collection model access the specific IInputModel.
6. Once accessed the model, subscribe to the desired input event.