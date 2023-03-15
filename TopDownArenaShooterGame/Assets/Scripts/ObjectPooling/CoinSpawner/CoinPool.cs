using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace ObjectPooling.CoinSpawner
{
    public class CoinPool: MonoBehaviour
    {
        [SerializeField] public Coin coin;

        public ObjectPool<Coin> Pool;

        private Vector3 _position = Vector3.zero;
        
        [SerializeField] private float range= 0f;

        private void OnEnable()
        {
            Pool = new ObjectPool<Coin>(CreateCoin, 
                OnEnableCoin, 
                OnDisableCoin, 
                OnDestroyCoin, 
                false, 50, 1000);
        }
        
        
        
        private Coin CreateCoin()
        {
            Coin producedCoin = Instantiate(coin, _position, Quaternion.identity);
            return producedCoin;
        }
        private void OnEnableCoin(Coin coin)
        {
            coin.transform.position = _position;
            coin.gameObject.SetActive(true);
        }
        private void OnDisableCoin(Coin coin)
        {
            coin.gameObject.SetActive(false);
        }
        private void OnDestroyCoin(Coin coin)
        {
            Destroy(coin.gameObject);
        }

        private void SetPosition(Vector3 position)
        {
            _position = Random.insideUnitSphere * range + position;
        }

        public void Spawn(Vector3 position)
        {
            SetPosition(position);
            Pool.Get(); // GET METHODU YAZ
        }

        public void CoinCollect(Coin coin)
        {
            Pool.Release(coin);
        }
    }
}