using System.Collections;
using Fire;
using Stats;
using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        private readonly Rigidbody2D rb2d;
        //public float Speed { private get; set;}

        private float speed;

        public void setSpeed(float speed)
        {
            this.speed = speed;
        }
        

        public PlayerMovement(Rigidbody2D rb2d)
        {
            this.rb2d = rb2d;
        }
        
        public void Move()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            var movement = new Vector2(horizontal, vertical);
            rb2d.velocity = movement * speed;
        }
    }
}