using UnityInputToObservable.Configs;

namespace UnityInputToObservable.DependencyInjection
{
    public class InputModelFactory<TActionMapType, TActionType> : IInputModelFactory<TActionMapType, TActionType>
        where TActionMapType : struct where TActionType : struct
    {
        private readonly IPlayerInputConfig _config;

        public InputModelFactory(IPlayerInputConfig config)
        {
            _config = config;
        }

        public IInputModel<TActionMapType, TActionType> Create(TActionMapType mapType) 
        {
            return new InputModel<TActionMapType, TActionType>(mapType, _config);
        }
    }
}