using UnityEngine;
using UnityEngine.Events;

namespace WeaponManager.Bullet
{
    public class ParabolicBaseBulletMovement : Base.BaseBullet
    {
        [Header("Movement")] [SerializeField] private float gravity;

        [SerializeField] private float time;
        public UnityEvent onGroundHitEvent;

        private Vector2 _groundVelocity;
        private bool _isGrounded;
        private float _verticalVelocity;


        protected  void Update()
        {
            Move();
            CheckGroundHit();
        }


        public override void Fire(Vector2 targetRelativePosition)
        {
            var distance = targetRelativePosition.magnitude;
            _isGrounded = false;
            _groundVelocity = targetRelativePosition.normalized * distance / time;
            _verticalVelocity = -(gravity / 2) * time;
        }

        private void Move()
        {
            if (!_isGrounded)
            {
                _verticalVelocity += gravity * Time.deltaTime;
                trnsBody.position += new Vector3(0, _verticalVelocity, 0) * Time.deltaTime;
            }

            trnsObject.position += (Vector3)_groundVelocity * Time.deltaTime;
        }

        private void CheckGroundHit()
        {
            if (trnsBody.position.y < trnsObject.position.y && !_isGrounded)
            {
                trnsBody.position = trnsObject.position;
                _isGrounded = true;
                onGroundHitEvent?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}