using UnityEngine;

namespace OldStats
{
    [CreateAssetMenu(menuName = "Upgrade")]
    public abstract class Upgrade : ScriptableObject
    {
        //public Sprite icon {get; private set;}

        public string upgradeName;
        [SerializeField] private string description;
        public int price;
        public string Description => description;
    }
}