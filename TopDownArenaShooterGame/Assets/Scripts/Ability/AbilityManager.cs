using UnityEngine;

namespace Ability
{
    [CreateAssetMenu(menuName = "AbilityManager")]
    public class AbilityManager : ScriptableObject
    {
        public AbilityHolder q;
        public AbilityHolder e;
        public AbilityHolder space;
    }
}