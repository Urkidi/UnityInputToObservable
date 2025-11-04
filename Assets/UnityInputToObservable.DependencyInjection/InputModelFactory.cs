using UnityInputToObservable.Configs;
using UnityInputToObservable.Enums;

namespace UnityInputToObservable.DependencyInjection
{
    public class InputModelFactory : IInputModelFactory
    {
        private readonly IPlayerInputConfig _config;

        public InputModelFactory(IPlayerInputConfig config)
        {
            _config = config;
        }
        
        public IInputModel Create(ActionMapType mapType)
        {
            return new InputModel(mapType, _config);
        }
    }
}