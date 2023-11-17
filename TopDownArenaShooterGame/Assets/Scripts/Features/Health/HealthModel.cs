using UniRx;

namespace Features.Health
{
    public class HealthModel
    {
        public ReactiveProperty<float> HealthPoint { get; }
        public ReactiveProperty<float> MaxHealthPoint { get; }
        
        public HealthModel(float initialHealthPoint, float maxHealthPoint)
        {
            HealthPoint = new ReactiveProperty<float>(initialHealthPoint);
            MaxHealthPoint = new ReactiveProperty<float>(maxHealthPoint);
        }
        
        public HealthModel(float maxHealthPoint)
        {
            HealthPoint = new ReactiveProperty<float>(maxHealthPoint);
            MaxHealthPoint = new ReactiveProperty<float>(maxHealthPoint);
        } 
    }
}