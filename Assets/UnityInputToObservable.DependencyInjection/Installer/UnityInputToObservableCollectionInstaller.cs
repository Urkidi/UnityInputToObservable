using System;
using Microsoft.Extensions.DependencyInjection;
using UnityInputToObservable.Configs;

namespace UnityInputToObservable.DependencyInjection.Installer
{
    public static class UnityInputToObservableCollectionInstaller
    {
        public static IServiceCollection InstallPackage(this IServiceCollection services)
        {
            services.AddSingleton<IInputModelFactory>(provider =>
                new InputModelFactory((IPlayerInputConfig)provider.GetService(typeof(IPlayerInputConfig))));
            
            services.AddSingleton<IInputCollectionModel, InputCollectionModel>();
            
            return services;
        }
    }
}