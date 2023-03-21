using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        private readonly Rigidbody2D _rb2d;

        public PlayerMovement(Rigidbody2D rb2d)
        {
            this._rb2d = rb2d;
        }

        public void Move(float speed)
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            var movement = new Vector2(horizontal, vertical).normalized;
            _rb2d.velocity = movement * speed;
        }
    }
}