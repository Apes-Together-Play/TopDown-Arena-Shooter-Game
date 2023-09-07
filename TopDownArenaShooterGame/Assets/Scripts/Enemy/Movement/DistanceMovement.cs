using UnityEngine;

namespace Enemy.Movement
{
    public class DistanceMovement : Movement
    {
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;
        
        private Transform _target;

        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        
        private void Update()
        {
            Vector2 direction;
            var distance = Vector2.Distance(transform.position, _target.position);

            if (distance <= minDistance)
                direction = (transform.position - _target.position).normalized;
            else if (distance >= maxDistance)
                direction = (_target.position - transform.position).normalized;
            else
                direction = Vector2.zero;

            Rigidbody.velocity = direction * Speed;
        }
    }
}