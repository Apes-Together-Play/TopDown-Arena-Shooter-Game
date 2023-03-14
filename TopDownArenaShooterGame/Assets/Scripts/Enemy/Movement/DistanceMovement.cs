using UnityEngine;

namespace Enemy.Movement
{
    public class DistanceMovement:Movement
    {
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;

        private Transform _targetTransform;

        protected new void Start()
        {
            base.Start();
            _targetTransform = _targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        protected override void Move()
        {
            Vector2 direction;
            float distance = Vector2.Distance(transform.position, _targetTransform.transform.position);
           
            if (distance <= minDistance) 
                direction = (transform.position - _targetTransform.position).normalized;
            else if (distance >= maxDistance) 
                direction = (_targetTransform.position -transform.position).normalized;
            else 
                direction = Vector2.zero;

            Rb2D.velocity = (direction)*Speed;
        }
    }
}