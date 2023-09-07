using UnityEngine;

namespace Enemy.Movement
{
    public class FollowingMovement : Movement
    {
        [SerializeField] private float slowNumber;
        [SerializeField] private float noSpeedDist;

        private Transform _targetTransform;

        private void Start()
        {
            _targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void Update()
        {
            Vector2 distance = _targetTransform.position - transform.position;
            var direction = distance.normalized;

            if (distance.magnitude < noSpeedDist)
                Rigidbody.velocity = Vector2.zero;
            else
                Rigidbody.velocity = direction * Speed;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
                Speed *= slowNumber;
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
                Speed /= slowNumber;
        }
    }
}