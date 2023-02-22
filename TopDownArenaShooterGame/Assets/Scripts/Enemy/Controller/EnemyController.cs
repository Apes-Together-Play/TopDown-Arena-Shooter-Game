using System;
using DefaultNamespace;
using Stats;
using UnityEngine;

namespace Enemy.Controller
{
    public class EnemyController : MonoBehaviour, IMortal
    {
        [SerializeField] private float initialHp = 100f;

        private float hp;

        private void Awake()
        {
            hp = initialHp;
        }

        public void TakeDamage()
        {
            hp -= 10f;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}