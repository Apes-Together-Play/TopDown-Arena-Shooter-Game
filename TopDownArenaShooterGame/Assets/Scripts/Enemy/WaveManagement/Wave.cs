using System;
using Enemy.Controller;
using UnityEngine;

namespace Enemy.WaveManagement
{
    [CreateAssetMenu(fileName = "Wave", menuName = "Wave", order = 0)]
    public class Wave : ScriptableObject
    {
        public MiniWave[] enemyTypeCounts;
    }

    [Serializable]
    public struct MiniWave
    {
        public EnemyTypeCount[] enemies;
        public float timeInMinutes;
    }
    
    [Serializable]
    public struct EnemyTypeCount
    {
        public EnemyController enemyPrefab;
        public int number;
    }
}