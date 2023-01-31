
using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float speed;
        private Rigidbody2D _rigidbody2D;
        

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Vector2 direction = (target.position - transform.position).normalized;
            _rigidbody2D.velocity = (direction)*speed;
        }
        
        
    }
}