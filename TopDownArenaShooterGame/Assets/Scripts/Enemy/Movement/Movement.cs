using UnityEngine;

namespace Enemy.Movement
{
    public abstract class Movement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        protected Rigidbody2D Rigidbody => 
            _rigidbody == null ? GetComponent<Rigidbody2D>() : _rigidbody = GetComponent<Rigidbody2D>();
        
        public float Speed { protected get; set; }
        
    }
}