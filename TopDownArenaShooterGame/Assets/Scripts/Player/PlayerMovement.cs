using System.Collections;
using Fire;
using Stats;
using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        private readonly Rigidbody2D rb2d;
        public float Speed { private get; set;}

        public PlayerMovement(Rigidbody2D rb2d)
        {
            this.rb2d = rb2d;
        }
        
        public void Move()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            var movement = new Vector2(horizontal, vertical);
            rb2d.velocity = movement * Speed;
        }
    }
}