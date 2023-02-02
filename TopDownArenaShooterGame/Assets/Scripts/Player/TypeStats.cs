using Fire;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "TypeStats", menuName = "Stats", order = 0)]
    public class TypeStats : ScriptableObject
    {
        public Card stat;
        public Sprite sprite;
    }
}