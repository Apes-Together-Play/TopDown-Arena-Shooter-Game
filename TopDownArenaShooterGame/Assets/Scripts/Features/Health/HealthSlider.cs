using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Health
{

    public interface IHealthUser
    {
        public void SetHealth(HealthModel model);
    }

    public abstract class HealthView : MonoBehaviour, IHealthUser
    {
        public abstract void SetHealth(HealthModel model);
    } 
    
    public class HealthSlider : HealthView
    {
        [SerializeField] private Slider healthSlider;
        
        public override void SetHealth(HealthModel model)
        {
            healthSlider.value = model.HealthPoint.Value;
            healthSlider.maxValue = model.MaxHealthPoint.Value;
            
            model.HealthPoint
                .Subscribe(val => healthSlider.value = val)
                .AddTo(this);
            
            model.MaxHealthPoint
                .Subscribe(val => healthSlider.maxValue = val)
                .AddTo(this);
        }
    }
}