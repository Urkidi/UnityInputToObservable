using Microsoft.Extensions.DependencyInjection;
using UnityEngine;
using UnityInputToObservable.Configs;
using UnityInputToObservable.DependencyInjection.Installer;

namespace UnityInputToObservable.Sample
{
    public class DIInstaller : MonoBehaviour
    {
        [SerializeField] private PlayerInputConfig _inputConfig;

        private void Awake()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IPlayerInputConfig>(_inputConfig);
            services.InstallUnityInputToObservablePackage<ActionMapType, ActionType>();
            services.AddSingleton<InputTest>();

            var prov = services.BuildServiceProvider();
            prov.GetService<InputTest>();

        }
    }
}