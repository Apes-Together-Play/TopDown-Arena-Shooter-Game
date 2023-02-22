
using System;
using UnityEngine;

namespace WeaponManager.Bullet
{
    public class LinearBulletMovement : Bullet
    {
        [SerializeField] private float velocity;
        private Vector2 _direction;
        
        protected override void Move()
        {
            trnsObject.position += (Vector3)(_direction * velocity) * Time.deltaTime;
        }

        public override void Initialize(Vector2 targetRelativePosition)
        {
            _direction = targetRelativePosition.normalized;
        }
    }
}