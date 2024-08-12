using System.Collections.Generic;
using CodeBase.GameEnvironment.UI.Windows;
using UnityEngine;

namespace CodeBase.Data.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/WindowStaticData", fileName = "WindowStaticData")]
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}