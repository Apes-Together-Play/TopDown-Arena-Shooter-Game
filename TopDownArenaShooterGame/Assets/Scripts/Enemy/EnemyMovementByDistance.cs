using UnityEngine;

namespace Enemy
{
    public class EnemyMovementByDistance : MonoBehaviour
    {
        
        [SerializeField] private Transform target;
        [SerializeField] private float speed;
        private Rigidbody2D _rigidbody2D;
        private bool forward = true;
        [SerializeField] private float minD;
        [SerializeField] private float maxD;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            Vector2 direction = (target.position - transform.position).normalized;
            float distance = Vector2.Distance(transform.position, target.transform.position);
           
            if (distance <= minD) direction = (transform.position - target.position).normalized;
            else if (distance >= maxD) direction = (target.position -transform.position).normalized;
            else direction *= 0;

            _rigidbody2D.velocity = (direction)*speed;
        }
    }
}