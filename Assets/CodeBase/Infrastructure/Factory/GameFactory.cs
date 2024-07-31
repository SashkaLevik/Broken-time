using System.Collections.Generic;
using Assets.CodeBase.Infrastructure.AssetManagment;
using Assets.CodeBase.Infrastructure.SaveLoad;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public List<ISaveProgress> ProgressWriters { get; } = new List<ISaveProgress>();

        public List<ILoadProgress> ProgressReaders { get; } = new List<ILoadProgress>();

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreteMenuHud()
        {
            GameObject menuHud = _assetProvider.Instantiate(AssetPath.MenuHud);
            RegisterProgressWatchers(menuHud);
            return menuHud;
        }

        private void RegisterProgressWatchers(GameObject obj)
        {
            foreach (ILoadProgress progressReader in obj.GetComponentsInChildren<ILoadProgress>())
            {
                Register(progressReader);
            }
        }

        private void Register(ILoadProgress progressReader)
        {
            if (progressReader is ISaveProgress progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }
    }
}