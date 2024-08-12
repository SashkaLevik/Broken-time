using System.Collections.Generic;
using CodeBase.Data.StaticData;
using CodeBase.GameEnvironment.UI.Windows;
using UnityEngine;
using System.Linq;

namespace CodeBase.Infrastructure.Services
{
    public class StaticDataService : IStaticDataService
    {
        private const string Windowdatapath = "UI/WindowStaticData";
        private Dictionary<WindowId, WindowConfig> _windowConfigs;

        public void LoadWindowData()
        {
            _windowConfigs = Resources.Load<WindowStaticData>(Windowdatapath)
                .Configs
                .ToDictionary(x => x.WindowId, x => x);
        }

        public WindowConfig ForWindow(WindowId windowId) =>
            _windowConfigs.TryGetValue(windowId, out WindowConfig windowConfig)
                ? windowConfig
                : null;
    }
}