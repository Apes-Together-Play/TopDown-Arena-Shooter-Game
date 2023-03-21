using System.Collections;
using UnityEngine;

namespace Enemy.WaveManagement
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private Wave[] waves;
        [SerializeField] private Vector2[] spawnPositions;
        [SerializeField] private float circleRadius;
        [SerializeField] private float enemySpawnWaitingTime;

        private int _level;

        private void Start()
        {
            StartCoroutine(SpawnWave());
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            foreach (var position in spawnPositions) Gizmos.DrawSphere(position, circleRadius);
        }

        private IEnumerator SpawnWave()
        {
            foreach (var wave in waves)
            foreach (var miniWave in wave.miniWaves)
            {
                var randomPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];
                foreach (var enemy in miniWave.enemies)
                    for (var i = 0; i < enemy.number; i++)
                    {
                        var e = Instantiate(enemy.enemyPrefab, randomPosition + Random.insideUnitCircle * circleRadius,
                            Quaternion.identity);
                        yield return new WaitForSeconds(enemySpawnWaitingTime);
                    }

                yield return new WaitForSeconds(miniWave.timeInSeconds);
            }
        }
    }
}