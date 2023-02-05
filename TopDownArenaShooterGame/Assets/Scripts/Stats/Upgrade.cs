using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(menuName = "Upgrade")]
    public abstract class Upgrade : ScriptableObject
    {
        //public Sprite icon {get; private set;}

        public string upgradeName;
        public string Description { get; private set; }

        public int price;

        public abstract void DoUpgrade();
    }
}