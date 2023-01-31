using System;
using Player;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float speed;
        private Rigidbody2D _rigidbody2D;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            target.gameObject.GetComponentInChildren<PlayerController>();
        }

        private void Update()
        {
            Vector2 speedVector;
            Vector2 distanceVector = (target.position - transform.position);
            
            Vector2 direction = distanceVector.normalized;
            speedVector = direction * speed;
            
            
            _rigidbody2D.velocity = speedVector;
        }
    }
}