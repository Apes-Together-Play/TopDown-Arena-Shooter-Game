using UnityEngine;

namespace Fire
{
    [CreateAssetMenu(fileName = "Card", menuName = "Card", order = 0)]
    public class Card : ScriptableObject
    {
        [SerializeField] private float hp;
        [SerializeField] private float hpRegen;
        [SerializeField] private float damage;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float lifeSteal;
        [SerializeField] private float critChange;
        [SerializeField] private float critDamage;
        [SerializeField] private float armor;
        [SerializeField] private float dodge;
        [SerializeField] private float knockback;
        [SerializeField] private float damageReflection;
        [SerializeField] private float speed;
        [SerializeField] private float luck;
        [SerializeField] private float harvesting;
        [SerializeField] private float hpRate;
        [SerializeField] private float hpRegenRate;
        [SerializeField] private float damageRate;
        [SerializeField] private float attackSpeedRate;
        [SerializeField] private float lifeStealRate;
        [SerializeField] private float critChangeRate;
        [SerializeField] private float critDamageRate;
        [SerializeField] private float armorRate;
        [SerializeField] private float dodgeRate;
        [SerializeField] private float knockbackRate;
        [SerializeField] private float damageReflectionRate;
        [SerializeField] private float speedRate;
        [SerializeField] private float luckRate;
        [SerializeField] private float harvestingRate;
    };
}