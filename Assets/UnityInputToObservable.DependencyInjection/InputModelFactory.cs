using UnityInputToObservable.Configs;

namespace UnityInputToObservable.DependencyInjection
{
    public class InputModelFactory : IInputModelFactory
    {
        private readonly IPlayerInputConfig _config;

        public InputModelFactory(IPlayerInputConfig config)
        {
            _config = config;
        }

        public IInputModel<TActionMapType, TActionType> Create<TActionMapType, TActionType>(TActionMapType mapType) where TActionMapType : struct where TActionType : struct
        {
            return new InputModel<TActionMapType, TActionType>(mapType, _config);
        }
    }
}