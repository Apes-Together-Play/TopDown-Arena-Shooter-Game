
using UnityEngine;
using UnityEngine.Serialization;

namespace Fire
{
    public abstract class Weapon : MonoBehaviour
    {
        [FormerlySerializedAs("statsData")] [SerializeField] private Card cardData;
        [SerializeField] protected Bullet bullet;
        public abstract void Fire(FireData data);
    }
}