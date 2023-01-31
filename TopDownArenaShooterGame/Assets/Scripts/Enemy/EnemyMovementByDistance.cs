using UnityEngine;

namespace Enemy
{
    public class EnemyMovementByDistance : MonoBehaviour
    {
        
        [SerializeField] private Transform target;
        [SerializeField] private float speed;
        private Rigidbody2D _rigidbody2D;
        [SerializeField] private float minD;
        [SerializeField] private float maxD;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector2 direction;
            float distance = Vector2.Distance(transform.position, target.transform.position);
           
            if (distance <= minD) 
                direction = (transform.position - target.position).normalized;
            else if (distance >= maxD) 
                direction = (target.position -transform.position).normalized;
            else 
                direction = Vector2.zero;

            _rigidbody2D.velocity = (direction)*speed;
        }
    }
}