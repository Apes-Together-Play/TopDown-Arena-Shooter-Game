using UnityEngine;

namespace Interfaces
{
    public interface IKnockable
    {
        void Knockback(float knockbackPower, float knockbackDuration, Vector2 direction, Rigidbody2D objectToKnockback)
        {
            float timer = 0;
            while (timer < knockbackDuration)
            {
                timer += Time.deltaTime;
                objectToKnockback.AddForce(direction * knockbackPower);
            }
        }
    }
}