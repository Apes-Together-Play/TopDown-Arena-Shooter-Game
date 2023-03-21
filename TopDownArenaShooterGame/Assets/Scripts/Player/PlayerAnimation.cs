using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        public SpriteRenderer sprRndDude;
        private Camera _mainCamera;
        private Vector2 _mouseWorldPos;

        private void Awake()
        {
            _mainCamera = FindObjectOfType<Camera>();
        }

        public void FlipDude()
        {
            _mouseWorldPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            sprRndDude.flipX = !(_mouseWorldPos.x > transform.position.x);
        }
    }
}