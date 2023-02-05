using Enemy.Movement;
using Player;
using UnityEngine;

namespace Ability
{
    [CreateAssetMenu]
    public class DashAbility: Ability
    /*
     * aslinda calisiyor ama player controller daki move fonksiyonu bunu manuel overrideliyor, bunu duzeltmemiz lazim fakat ayni zamanda player controller a kod yazmamamiz lazim
     */
    {
        [SerializeField] private float dashVelocity;
        public override void Active(GameObject parent)
        {
            Rigidbody2D rigidbody = parent.GetComponent<Rigidbody2D>();
            PlayerController player = parent.GetComponent<PlayerController>();
            
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            
            var movement = new Vector2(horizontal, vertical);
            movement.Normalize();

            rigidbody.velocity = dashVelocity * movement;


            //rigidbody.AddForce(movement * dashVelocity, ForceMode.Impulse);
        }
    }
}