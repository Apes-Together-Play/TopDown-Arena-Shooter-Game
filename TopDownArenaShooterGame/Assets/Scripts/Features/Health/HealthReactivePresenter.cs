using System;
using System.Globalization;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Features.Health
{
    public class HealthReactivePresenter : MonoBehaviour
    {
        [SerializeField] private HealthView healthView;
        private HealthModel _healthModel;
        private void Start()
        {
            healthView.SetHealth(_healthModel);
        }
    }


    public class HealthController :MonoBehaviour
    {
        private HealthModel _healthModel = new HealthModel(100);
        
        public UnityEvent<float> OnHealthPointChanged;
        public UnityEvent<float> OnDie;
        public UnityEvent<float> OnBorn;

        private void Start()
        {
            _healthModel.HealthPoint.Subscribe(val =>
            {
                OnHealthPointChanged?.Invoke(val);
                if (val <= 0)
                {
                    OnDie?.Invoke(val);
                }
            });
        }

        public void Damage(float damage)
        {
            _healthModel.HealthPoint.Value -= damage;
        }
        
        public void Heal(float heal)
        {
            _healthModel.HealthPoint.Value += heal;
        }
        
        public void RefreshHealth()
        {
            _healthModel.HealthPoint.Value = _healthModel.MaxHealthPoint.Value;
        }

        public void IncreaseMaxHealth(float health)
        {
            _healthModel.MaxHealthPoint.Value += health;
        }
        
        public void DecreaseMaxHealth(float health)
        {
            _healthModel.MaxHealthPoint.Value -= health;
        }
    }
    
}