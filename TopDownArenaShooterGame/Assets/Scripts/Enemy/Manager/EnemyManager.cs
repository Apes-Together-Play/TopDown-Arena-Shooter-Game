using System.Collections;
using Enemy.WaveManagement;
using UnityEngine;

namespace Enemy.Manager
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private Wave[] waves;
        
        private int level;
        private void Start()
        {
            StartCoroutine(SpawnWave());
        }
        
        private IEnumerator SpawnWave()
        {
            foreach (var miniWave in waves[0].enemyTypeCounts)
            {
                foreach (var enemy in miniWave.enemies)
                {
                    for (int i = 0; i < enemy.number; i++)
                    {
                        var e = Instantiate(enemy.enemyPrefab, transform.position, Quaternion.identity);
                        yield return new WaitForSeconds(0.3f);
                    }
                }

                yield return new WaitForSeconds(miniWave.timeInMinutes);
            }
        }
    }
}