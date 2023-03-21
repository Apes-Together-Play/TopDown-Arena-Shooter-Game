using UnityEngine;

namespace Enemy.Movement
{
    public class RandomMovement : Movement
    {
        private Vector2 _direction;


        private new void Start()
        {
            base.Start();
            ChangeDirection();
        }

        protected void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Wall")) ChangeDirection();
        }

        protected override void Move()
        {
            Rb2D.velocity = _direction * Speed;
        }

        private void ChangeDirection()
        {
            _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _direction.Normalize();
        }
    }
}