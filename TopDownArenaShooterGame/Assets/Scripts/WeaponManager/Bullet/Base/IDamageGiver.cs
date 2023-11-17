namespace WeaponManager.Bullet.Base
{
    public interface IDamageGiver
    {
        public void GiveDamage(IDamageTaker taker);
    }

    public interface IDamageTaker
    {
        public void TakeDamage(IDamageGiver giver);
    }
    
    public class DamageManager
    {
        public void GiveDamage(IDamageGiver giver, IDamageTaker taker)
        {
            giver.GiveDamage(taker);
        }
    }
}