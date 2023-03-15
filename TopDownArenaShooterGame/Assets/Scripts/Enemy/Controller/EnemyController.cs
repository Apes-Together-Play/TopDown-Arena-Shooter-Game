using System;
using DefaultNamespace;
using Stats;
using UnityEngine;

namespace Enemy.Controller
{
    public class EnemyController : MonoBehaviour, IMortal
    {
        [SerializeField] private float initialHp = 100f;
        [SerializeField] private Movement.Movement movement;
        private StatManager statManager;
        [SerializeField] private StatsUpgrade baseEnemyStat;
        
        public static event Action<float, Vector3> OnDeadAction;
        
        private float hp;

        private void Awake()
        {
            hp = initialHp;
            statManager = ScriptableObject.CreateInstance<StatManager>();
            statManager.AddUpgrade(baseEnemyStat);
        }

        private void Update()
        {
            movement.Speed = statManager.GetSpeed();
        }

        public void TakeDamage()
        {
            hp -= 10f;
            if (hp <= 0)
            {
                OnDeadAction?.Invoke(statManager.GetStats(StatType.money), gameObject.transform.position);
                Destroy(gameObject);
            }
        }
    }
}