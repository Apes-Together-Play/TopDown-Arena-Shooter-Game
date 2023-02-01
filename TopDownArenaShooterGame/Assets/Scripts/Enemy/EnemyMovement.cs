using DefaultNamespace;
using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour, IMortal
    {
        [SerializeField] private Transform target;
        private Rigidbody2D _rigidbody2D;
        [HideInInspector] public bool isTriggered;
        [SerializeField] private float normalSpeed;
        [SerializeField] private float slowSpeed = 2f;
        [SerializeField] private float noSpeedDist;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            target.gameObject.GetComponentInChildren<PlayerController>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector2 distance = (target.position - transform.position);
            Vector2 direction = distance.normalized;

            if (distance.magnitude < noSpeedDist)
                _rigidbody2D.velocity = Vector2.zero;
            else if (isTriggered)
                _rigidbody2D.velocity = direction * slowSpeed;
            else
                _rigidbody2D.velocity = direction * normalSpeed;
        }

        public void TakeDamage(float damage, float knockback)
        {
            Debug.Log(damage);
        }
    }
}