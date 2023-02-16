using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class BombMovement : MonoBehaviour
    {
        private bool isGrounded;
        
        private Vector2 groundVelocity;
        private float verticalVelocity;

        [Header("Objects")]
        [SerializeField] private Transform trnsObject;
        [SerializeField] private Transform trnsBody;
        
        [Header("Movement")]
        [SerializeField] private float gravity;
        
        public UnityEvent onGroundHitEvent;
        private void Update()
        {
            Move();
            CheckGroundHit();   
        }
        
        
        public void Initialize(Vector2 groundVelocity, float verticalVelocity)
        {
            // initial velocity will be 
            isGrounded = false;
            this.groundVelocity = groundVelocity;
            this.verticalVelocity = verticalVelocity;
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
                onGroundHitEvent?.Invoke();
                Destroy(gameObject);
            }

        }




    }
}