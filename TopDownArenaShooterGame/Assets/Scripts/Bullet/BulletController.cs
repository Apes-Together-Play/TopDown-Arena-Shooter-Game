using System;
using DefaultNamespace;
using Mono.Cecil;
using UnityEngine;

namespace Bullet
{
    public class BulletController : MonoBehaviour
    {
        public LayerMask layerMask;
        //public string[] tag;
        public float speed;
        public float damage;
        public float knockback;

        private Rigidbody2D _rigidbody2D;
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            var layer = col.gameObject.layer;
            if (layerMask == (layerMask | (1 << layer)))
            {
                Debug.Log("AAA");
                Destroy(gameObject);
                IMortal mortal = col.GetComponent<IMortal>();
                mortal?.TakeDamage(damage, knockback); // thank to Rider
            }
                
        }

        public void Fire(Vector2 direction)
        {
            _rigidbody2D.velocity = direction * speed;
        }
    }
}