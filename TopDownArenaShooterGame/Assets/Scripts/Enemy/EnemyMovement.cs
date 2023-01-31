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
        [HideInInspector] public bool isTriggered;
        [SerializeField] private float slowSpeedConst = 2f;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            target.gameObject.GetComponentInChildren<PlayerController>();
        }

        private void Update()
        {
            Vector2 direction = (target.position - transform.position).normalized;
            _rigidbody2D.velocity = (isTriggered) ? direction * slowSpeedConst : direction * speed;
        }
    }
}