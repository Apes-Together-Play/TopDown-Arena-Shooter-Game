using System.Collections;
using Ability;
using Features.Health;
using ObjectPooling.CoinSpawner;
using OldStats;
using UnityEngine;
using WeaponManager.Weapon;
using WeaponManager.Weapon.Base;

namespace Player
{
    public class Player : MonoBehaviour
    {
        // HADI BISMILLAHIRRAHMANIRRAHIM

        [SerializeField] private BaseWeapon[] weapons;
        [SerializeField] private PlayerAnimation playerAnimation;
        [SerializeField] private StatManager statManager;
        [SerializeField] private AbilityManager abilityManager;
        [SerializeField] private HealthController controller;

        private int _weaponIndex;
        private PlayerMovement _movement;
        private Rigidbody2D _rb2d;


        private void Awake()
        {
            //DontDestroyOnLoad(this);
            //Debug.Log(statManager.statsInfo[StatType.hp]);
            foreach (var weapon in weapons) weapon.gameObject.SetActive(false);
        }

        private void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _movement = new PlayerMovement(_rb2d);
            weapons[_weaponIndex].gameObject.SetActive(true);

            StartCoroutine(Fire());
        }

        private void Update()
        {
            _movement.Move(statManager.GetSpeed());
            ChangeWeapon();
            playerAnimation.FlipDude();
            ControlAbilities();
        }


        private void LateUpdate()
        {
            var currentWeapon = weapons[_weaponIndex];
            currentWeapon.RotateGun();
            currentWeapon.Flip();
        }

        private void OnEnable()
        {
            Coin.OnCoinCollectEvent += CollectCoin;
        }

        private void ControlAbilities()
        {
            abilityManager.q.StateTransition();
            abilityManager.e.StateTransition();
            abilityManager.space.StateTransition();
        }


        private void ChangeWeapon()
        {
            if (Input.GetKeyDown("1"))
            {
                weapons[_weaponIndex].gameObject.SetActive(false);
                _weaponIndex = 0;
                weapons[_weaponIndex].gameObject.SetActive(true);
            }

            if (Input.GetKeyDown("2"))
            {
                weapons[_weaponIndex].gameObject.SetActive(false);
                _weaponIndex = 1;
                weapons[_weaponIndex].gameObject.SetActive(true);
            }
        }

        public void TakeDamage(float damage)
        {
            controller.Damage(damage);
        }

        private IEnumerator Fire()
        {
            while (true)
            {
                if (Input.GetMouseButton(0))
                {
                    var currentWeapon = weapons[_weaponIndex];
                    
                    AttackStatHelper helper = new AttackStatHelper(
                        statManager.GetStats(StatType.Knockback), statManager.GetStats(StatType.LifeSteal), statManager.GetDamage()
                        );
                    
                    currentWeapon.Shoot(helper);
                    var cooldown = 1 / currentWeapon.AttackSpeed;

                    cooldown *= statManager.GetAttackSpeed();
                    yield return new WaitForSeconds(cooldown);
                }

                yield return null;
            }
        }

        public void CollectCoin(Coin coin)
        {
            statManager.SetStat(StatType.Money, coin.value);
            Debug.Log(statManager.GetStats(StatType.Money));
        }
    }
}