using Enemy.Controller;
using UnityEngine;

namespace ObjectPooling.CoinSpawner
{
    public class CoinSpawnManager : MonoBehaviour
    {
        [SerializeField] private CoinPool bronzeCoinPool;
        [SerializeField] private CoinPool silverCoinPool;
        [SerializeField] private CoinPool goldCoinPool;

        public void OnEnable()
        {
            EnemyController.OnDeadAction += SpawnCoin;
            Coin.OnCoinCollectEvent += CoinCollect;
        }


        public void SpawnCoin(float value, Vector3 position)
        {
            while (value >= goldCoinPool.coin.value)
            {
                goldCoinPool.Spawn(position);
                value -= goldCoinPool.coin.value;
            }

            while (value >= silverCoinPool.coin.value)
            {
                silverCoinPool.Spawn(position);
                value -= silverCoinPool.coin.value;
            }

            while (value >= bronzeCoinPool.coin.value)
            {
                bronzeCoinPool.Spawn(position);
                value -= bronzeCoinPool.coin.value;
            }
        }

        public void CoinCollect(Coin coin)
        {
            switch (coin.type)
            {
                case CoinType.Gold:
                    goldCoinPool.Pool.Release(coin);
                    break;
                case CoinType.Silver:
                    silverCoinPool.Pool.Release(coin);
                    break;
                case CoinType.Bronze:
                    bronzeCoinPool.Pool.Release(coin);
                    break;
            }
        }
    }
}