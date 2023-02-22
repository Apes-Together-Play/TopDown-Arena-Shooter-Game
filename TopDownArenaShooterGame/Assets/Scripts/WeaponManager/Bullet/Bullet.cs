using System;
using Enemy.Movement;
using UnityEngine;

namespace WeaponManager.Bullet
{
    public abstract class Bullet : MonoBehaviour
    {
        [Header("Objects")]
        [SerializeField] protected Transform trnsObject;
        [SerializeField] protected Transform trnsBody;

        protected abstract void Move();

        public abstract void Initialize(Vector2 targetRelativePosition);
        
        protected void Update()
        {
            Move();
        }
        
        
    }
}