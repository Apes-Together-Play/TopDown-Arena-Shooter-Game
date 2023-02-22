using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Vector2 mouseWorldPos;
        
        public SpriteRenderer sprRndDude;
        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = FindObjectOfType<Camera>();
        }

        public void FlipDude()
        {
            mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            sprRndDude.flipX = !(mouseWorldPos.x > transform.position.x);
        }
    }
}