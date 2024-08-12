using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.GameEnvironment.UI
{
    public class CustomButton : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField] private float _alfa;

        private void Start()
        {
            GetComponent<Image>().alphaHitTestMinimumThreshold = _alfa;
        }
    }
}