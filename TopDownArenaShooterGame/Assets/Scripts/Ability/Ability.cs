using UnityEngine;

namespace Ability
{
    public abstract class Ability : ScriptableObject
    {
        public new string name;
        public float cooldownTime;
        public float activeTime;

        public abstract void Active();

        public abstract void DeActive();
    }
}