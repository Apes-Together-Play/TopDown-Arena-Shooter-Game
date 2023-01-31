using System;
using Enemy;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;

        private Rigidbody2D _rb2d;

        private void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
        
            var movement = new Vector2(horizontal, vertical);
            _rb2d.velocity = movement * speed;
        }
        
        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                Debug.Log(col.gameObject.name);
                //col.gameObject.GetComponent<EnemyMovement>().Speed = 0;
            }
        }
    }
}