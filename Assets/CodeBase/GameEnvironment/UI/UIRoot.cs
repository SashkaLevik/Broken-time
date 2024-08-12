using System;
using UnityEngine;

namespace CodeBase.GameEnvironment.UI
{
    public class UIRoot : MonoBehaviour
    {
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.worldCamera = Camera.main;
        }
    }
}