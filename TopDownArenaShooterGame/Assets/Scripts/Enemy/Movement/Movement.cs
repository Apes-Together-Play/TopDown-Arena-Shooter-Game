using UnityEngine;

namespace Enemy.Movement
{
    public abstract class Movement : MonoBehaviour
    {
        protected Rigidbody2D Rb2D;
        [SerializeField] protected float speed;

        protected void Start()
        {
            Rb2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }

        protected abstract void Move();
    }
}