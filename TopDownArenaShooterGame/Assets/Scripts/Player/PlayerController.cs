using System;
using System.Collections;
using System.Collections.Generic;
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
            StartCoroutine(Fire());
        }

        private void Update()
        {
            Move();
        }
        
        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                var enemyMovement = col.gameObject.GetComponent<EnemyMovement>();
                if(enemyMovement) 
                    enemyMovement.isTriggered = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                var enemyMovement = col.gameObject.GetComponent<EnemyMovement>();
                if(enemyMovement) 
                    enemyMovement.isTriggered = false;
            }
        }
        
        private void Move()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            var movement = new Vector2(horizontal, vertical);
            _rb2d.velocity = movement * speed;
        }

        private IEnumerator Fire()
        {
            while (true)
            {
                Debug.Log(Input.mousePosition);
                yield return new WaitForSeconds(10);
            }
        }
    }
}