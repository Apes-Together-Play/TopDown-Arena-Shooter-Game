using System;
using Enemy.Controller;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy.WaveManagement
{
    [CreateAssetMenu(fileName = "Wave", menuName = "Wave", order = 0)]
    public class Wave : ScriptableObject
    {
        [FormerlySerializedAs("enemyTypeCounts")]
        public MiniWave[] miniWaves;
    }

    [Serializable]
    public struct MiniWave
    {
        public EnemyTypeCount[] enemies;

        [FormerlySerializedAs("timeInMinutes")]
        public float timeInSeconds;
    }

    [Serializable]
    public struct EnemyTypeCount
    {
        public EnemyController enemyPrefab;
        public int number;
    }
}