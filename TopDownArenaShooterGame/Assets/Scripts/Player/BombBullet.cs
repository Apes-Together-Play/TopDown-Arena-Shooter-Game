using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class BombBullet : BulletMovement
    {
        private bool isGrounded;
        
        private Vector2 groundVelocity;
        private float verticalVelocity;
        private float lastIntialVerticalVelocity;
        
        public Transform trnsObject;
        public Transform trnsBody;
        public Transform trnsShadow;
        
        public UnityEvent onGroundHitEvent;

        
        [SerializeField] private float gravity;
        
        private void Update()
        {
            Move();
            CheckGroundHit();   
        }
        
        
        public void Initialize(Vector2 groundVelocity, float verticalVelocity)
        {
            isGrounded = false;
            this.groundVelocity = groundVelocity;
            this.verticalVelocity = verticalVelocity;
            lastIntialVerticalVelocity = verticalVelocity;
        }
        
        void Move()
        {
            if (!isGrounded) 
            {
                verticalVelocity += gravity * Time.deltaTime;
                trnsBody.position += new Vector3(0, verticalVelocity, 0) * Time.deltaTime;
            }

            trnsObject.position += (Vector3)groundVelocity * Time.deltaTime;
        }
        
        void CheckGroundHit(){

            if(trnsBody.position.y < trnsObject.position.y && !isGrounded){

                trnsBody.position = trnsObject.position;
                isGrounded = true;
                onGroundHitEvent.Invoke();
            }

        }
        
        
        
        

    }
}