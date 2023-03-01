using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(menuName = "Upgrade")]
    public abstract class Upgrade : ScriptableObject
    {
        //public Sprite icon {get; private set;}

        public string upgradeName;
        [SerializeField] private string description;
        public string Description => description;

        public int price;

        public abstract void DoUpgrade(Player.Player player);
    }
}