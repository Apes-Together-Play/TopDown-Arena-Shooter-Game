using WeaponManager.Bullet.Base;

namespace GameMechanicObjects
{
    public interface IBulletHandler
    {
        public void HandleBullet(BulletData bullet);
    }
}