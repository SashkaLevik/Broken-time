using System.Collections.Generic;
using CodeBase.GameEnvironment.UI.Windows;
using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Infrastructure.SaveLoad;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IPersistentProgressService _progressService;
        private readonly IStaticDataService _staticData;

        private GameObject _garage;
        private WindowBase[] _windows;
        
        public List<ISaveProgress> ProgressWriters { get; } = new List<ISaveProgress>();
        public List<ILoadProgress> ProgressReaders { get; } = new List<ILoadProgress>();

        public GameFactory(IAssetProvider assetProvider, IStaticDataService staticData, 
            IPersistentProgressService progressService)
        {
            _assetProvider = assetProvider;
            _staticData = staticData;
            _progressService = progressService;
        }

        public GameObject CreteMenuHud()
        {
            GameObject menuHud = _assetProvider.Instantiate(AssetPath.MenuHud);
            RegisterProgressWatchers(menuHud);
            return menuHud;
        }

        public GameObject CreateGarage()
        {
            _garage = _assetProvider.Instantiate(AssetPath.Garage);
            RegisterProgressWatchers(_garage);
            return _garage;
        }

        public GameObject CreateTruckConstructor()
        {
            GameObject truckConstructor = _assetProvider.InstantiateInParent(AssetPath.TruckConstructor, _garage.transform);
            _windows = Resources.LoadAll<WindowBase>(AssetPath.ConstructWindows);
            OpenWindowButton[] buttons = truckConstructor.GetComponentsInChildren<OpenWindowButton>();

            for (int i = 0; i < _windows.Length; i++)
            {
                var currentWindow = Object.Instantiate(_windows[i], _garage.transform);
                buttons[i].Initialize(currentWindow);
                currentWindow.gameObject.SetActive(false);
            }

            RegisterProgressWatchers(truckConstructor);
            return truckConstructor;
        }

        private void RegisterProgressWatchers(GameObject obj)
        {
            foreach (ILoadProgress progressReader in obj.GetComponentsInChildren<ILoadProgress>())
                Register(progressReader);
        }

        private void Register(ILoadProgress progressReader)
        {
            if (progressReader is ISaveProgress progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }
    }
}