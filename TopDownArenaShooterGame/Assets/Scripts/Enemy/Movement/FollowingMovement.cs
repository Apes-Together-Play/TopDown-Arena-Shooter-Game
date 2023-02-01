using UnityEngine;

namespace Enemy.Movement
{
    public class FollowingMovement : Movement
    {
        [SerializeField] private float slowNumber;
        [SerializeField] private float noSpeedDist;

        private Transform _targetTransform;
        
        private new void Start()
        {
            base.Start();
            _targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        
        protected override void Move()
        {
            Vector2 distance = (_targetTransform.position - transform.position);
            var direction = distance.normalized;

            if (distance.magnitude < noSpeedDist)
                Rb2D.velocity = Vector2.zero;
            else
                Rb2D.velocity = direction * speed;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
                speed *= slowNumber;
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
                speed /= slowNumber;
        }
    }
}