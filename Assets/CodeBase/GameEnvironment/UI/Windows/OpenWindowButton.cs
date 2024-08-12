using System;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.GameEnvironment.UI.Windows
{
    public class OpenWindowButton : MonoBehaviour
    {
        public Button OpenButton;
        public WindowId WindowId;
        private WindowBase _window;

        public void Initialize(WindowBase windowBase)
        {
            if (WindowId == windowBase.WindowId) 
                _window = windowBase;
        }

        private void Awake() =>
            OpenButton.onClick.AddListener(Open);

        private void OnDestroy() => 
            OpenButton.onClick.RemoveListener(Open);

        private void Open() =>
            _window.gameObject.SetActive(true);
    }
}