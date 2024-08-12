using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.GameEnvironment.UI.Windows
{
    public class WindowBase : MonoBehaviour
    {
        [SerializeField] protected Button CloseButton;
        public WindowId WindowId;

        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake() => 
            CloseButton.onClick.AddListener(() => gameObject.SetActive(false));
    }
}