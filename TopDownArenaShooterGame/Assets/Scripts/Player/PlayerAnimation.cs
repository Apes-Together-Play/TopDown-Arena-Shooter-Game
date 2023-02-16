using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Vector2 mouseWorldPos;
        
        public SpriteRenderer sprRndDude;
        public SpriteRenderer sprRndGun;
        
        public void FlipDude()
        {

            mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(mouseWorldPos.x > transform.position.x)
            {
                sprRndDude.flipX = false;
                sprRndGun.flipY = false;
            }
            else
            {
                sprRndDude.flipX = true;
                sprRndGun.flipY = true;
            }
        }
    }
}