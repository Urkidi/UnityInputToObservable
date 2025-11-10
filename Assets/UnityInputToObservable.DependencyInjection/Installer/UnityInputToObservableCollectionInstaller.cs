using Microsoft.Extensions.DependencyInjection;
using UnityInputToObservable.Configs;

namespace UnityInputToObservable.DependencyInjection.Installer
{
    public static class UnityInputToObservableCollectionInstaller
    {
        public static IServiceCollection InstallUnityInputToObservablePackage<TActionMap, TActionType>(this IServiceCollection services) where TActionMap : struct where TActionType : struct
        {
            services.AddSingleton<IInputModelFactory<TActionMap, TActionType>>(provider =>
                new InputModelFactory<TActionMap, TActionType>((IPlayerInputConfig)provider.GetService(typeof(IPlayerInputConfig))));
            
            services.AddSingleton<IInputCollectionModel<TActionMap, TActionType>, InputCollectionModel<TActionMap, TActionType>>();
            
            return services;
        }
    }
}