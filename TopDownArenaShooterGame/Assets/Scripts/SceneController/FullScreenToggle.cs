using UnityEngine;
using UnityEngine.UI;

namespace SceneController
{
    public class FullScreenToggle : MonoBehaviour
    {
        [SerializeField] private Sprite minimize;
        [SerializeField] private Sprite maximize;
        [SerializeField] private Image image;

        private void Start()
        {
            image.sprite = Screen.fullScreen ? minimize : maximize;
        }

        public void Toggle()
        {
            Screen.fullScreen = !Screen.fullScreen;
            image.sprite = Screen.fullScreen ? minimize : maximize;
        }
    }
}