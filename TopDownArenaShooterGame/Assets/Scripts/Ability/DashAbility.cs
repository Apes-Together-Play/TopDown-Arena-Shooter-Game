using System;
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

        public static event Action<float> OnDashAbility;

        public override void Active(GameObject parent)
        {
            
            OnDashAbility?.Invoke(dashVelocity);

        }

        public override void DeActive(GameObject parent)
        {
            OnDashAbility?.Invoke(1/dashVelocity);
        }
    }
}