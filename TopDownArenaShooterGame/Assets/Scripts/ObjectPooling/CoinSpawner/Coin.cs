using System;
using Unity.VisualScripting;
using UnityEngine;

namespace ObjectPooling.CoinSpawner
{
    [Serializable]
    public class Coin : MonoBehaviour
    {
        public static event Action<Coin> OnCoinCollectEvent;
        [SerializeField] public int value;
        [SerializeField] public CoinType type;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
                OnCoinCollectEvent?.Invoke(this);
        }
    }
}