using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.SO.Settings
{
    [CreateAssetMenu(fileName = "SpawnSettings", menuName = "SO/Settings/SpawnSettings")]
    public class SpawnSettings : ScriptableObject
    {
        public List<Transform> PlayerSpawnPoints;
        
        public List<Transform> EnemySpawnPoints;
    }
}