namespace OldStats
{
    public enum StatType
    {
        // 000000000000000000000000 MEANS SEND IT TO THE BULLET
        //todo this enum maybe change later
        Hp, // 100 at the beginning
        CurrentHp, // her market asamasinda hp ye esitlenir, when it's 0 gg wp cerEZ, mayonEZ, karincaincitmEZ,
        HpRegen, // 1/5 * x^1/2
        Damage, // 0 at the beginning      000000000000000000000000
        AttackSpeed, // silah cooldown'ini % li yapiyor + ve - olabilir 
        LifeSteal, // 000000000000000000000000
        CriticChange, // 
        CriticDamage, // 
        Armor, // +- 5 x^(1/2) -> upper bound 90;
        Dodge, // x  upper bound 60 
        Knockback, // 000000000000000000000000
        DamageReflection, // (0, oo)
        Speed, // herkeste base speed var bizim aldigimiz upgrade'ler
        SpeedPercentage, // speed ile yuzdeli carpiliyor %100 2 kati hizli, -%100 iki kati yavas vs
        Luck,
        Harvesting, // tur bitiminde para, duz sayi iste aq  


        HpRate,
        HpRegenRate,
        DamageRate,
        AttackSpeedRate,
        LifeStealRate,
        CriticChangeRate,
        CriticDamageRate,
        ArmorRate,
        DodgeRate,
        KnockbackRate,
        DamageReflectionRate,
        SpeedRate,
        LuckRate,
        HarvestingRate,

        Money
    }
}