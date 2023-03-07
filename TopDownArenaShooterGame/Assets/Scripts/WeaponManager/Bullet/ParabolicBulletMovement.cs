using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponManager.Bullet
{
    public class ParabolicBulletMovement : Bullet
    {
        private bool isGrounded;
        
        private Vector2 groundVelocity;
        private float verticalVelocity;
        
        [Header("Movement")]
        [SerializeField] private float gravity;

        [SerializeField] private float time;
        public UnityEvent onGroundHitEvent;
        

        protected new void Update()
        {
            base.Update();
            CheckGroundHit();
        }
        
        
        public override void Initialize(Vector2 targetRelativePosition)
        {
            var distance = targetRelativePosition.magnitude;
            isGrounded = false;
            groundVelocity = targetRelativePosition.normalized * distance/time;
            verticalVelocity = -(gravity/2)*time;
        }
        
        protected override void Move()
        {
            if (!isGrounded) 
            {
                verticalVelocity += gravity * Time.deltaTime;
                trnsBody.position += new Vector3(0, verticalVelocity, 0) * Time.deltaTime;
            }
            trnsObject.position += (Vector3)groundVelocity * Time.deltaTime;
        }
        
        private void CheckGroundHit(){

            if(trnsBody.position.y < trnsObject.position.y && !isGrounded){

                trnsBody.position = trnsObject.position;
                isGrounded = true;
                onGroundHitEvent?.Invoke();
                Destroy(gameObject);
            }
            
        }
    }
}