using System;
using Stats;
using UnityEngine;

namespace Enemy.Controller
{
    public class EnemyController : MonoBehaviour, IMortal
    {
        [SerializeField] private float initialHp = 100f;
        [SerializeField] private Movement.Movement movement;
        [SerializeField] private StatsUpgrade baseEnemyStat;

        private float _hp;
        private StatManager _statManager;

        private void Awake()
        {
            _hp = initialHp;
            _statManager = ScriptableObject.CreateInstance<StatManager>();
            _statManager.AddUpgrade(baseEnemyStat);
        }

        private void Update()
        {
            movement.Speed = _statManager.GetSpeed();
        }

        public void TakeDamage()
        {
            _hp -= 10f;
            if (_hp <= 0)
            {
                OnDeadAction?.Invoke(_statManager.GetStats(StatType.Money), gameObject.transform.position);
                Destroy(gameObject);
            }
        }

        public static event Action<float, Vector3> OnDeadAction;
    }
}