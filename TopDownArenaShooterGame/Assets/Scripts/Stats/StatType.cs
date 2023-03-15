namespace Stats
{
    public enum StatType
    {
        //todo this enum maybe change later
        hp, // 100 at the beginning
        currentHP, // her market asamasinda hp ye esitlenir, when it's 0 gg wp cerEZ, mayonEZ, karincaincitmEZ,
        hpRegen, // 1/5 * x^1/2
        damage, // 0 at the beginning
        attackSpeed, // silah cooldown'ini % li yapiyor + ve - olabilir
        lifeSteal, // 
        criticChange, // 
        criticDamage, // 
        armor, // +- 5 x^(1/2) -> upper bound 90;
        dodge, // x  upper bound 60 
        knockback, // 
        damageReflection, // (0, oo)
        speed, // herkeste base speed var bizim aldigimiz upgrade'ler
        speedPercentage, // speed ile yuzdeli carpiliyor %100 2 kati hizli, -%100 iki kati yavas vs
        luck, 
        harvesting, // tur bitiminde para, duz sayi iste aq  
        
        
        hpRate,
        hpRegenRate,
        damageRate,
        attackSpeedRate,
        lifeStealRate,
        criticChangeRate,
        criticDamageRate,
        armorRate,
        dodgeRate,
        knockbackRate,
        damageReflectionRate,
        speedRate,
        luckRate,
        harvestingRate,
        
        money
    }
}