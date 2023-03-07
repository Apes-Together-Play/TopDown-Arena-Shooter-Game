using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        private readonly Rigidbody2D rb2d;
        private float speed;
        public void SetSpeed(float speed) => this.speed = speed;

        public void SetSpeedByMultiply(float increaseConstant) => speed *= increaseConstant;

        public PlayerMovement(Rigidbody2D rb2d)
        {
            this.rb2d = rb2d;
        }

        public void Move()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            var movement = new Vector2(horizontal, vertical).normalized;
            rb2d.velocity = movement * speed;
        }
    }
}