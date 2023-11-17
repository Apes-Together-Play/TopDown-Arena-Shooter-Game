using UniRx;

namespace Stats.Base
{
    public abstract class Stat<T>
    {
        private T _value;

        public ReactiveProperty<T> Property { get; private set; }
    }
}