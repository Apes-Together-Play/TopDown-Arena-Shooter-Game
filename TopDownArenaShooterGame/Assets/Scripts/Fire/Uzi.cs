using UnityEngine;

namespace Fire
{
    public class Uzi : Weapon
    {
        public override void Fire(FireData fireData)
        {
            Instantiate(bullet);
            
        }
    }
}