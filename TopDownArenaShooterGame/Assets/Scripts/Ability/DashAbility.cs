using System;
using Enemy.Movement;
using Player;
using UnityEngine;

namespace Ability
{
    [CreateAssetMenu]
    public class DashAbility: Ability
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