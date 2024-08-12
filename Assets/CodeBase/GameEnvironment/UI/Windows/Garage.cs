using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.GameEnvironment.UI.Windows
{
    public class Garage : MonoBehaviour
    {
        [SerializeField] private List<Button> _constructButtons;

        private void Awake()
        {
            foreach (var button in _constructButtons)
            {
            }
        }

        private void OpenWindow(WindowId windowId)
        {
        }
    }
}