using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StaticData/Enemies/SpawnerConfig", fileName = "SpawnerConfig", order = 54)]
public class EnemySpawnerConfig : ScriptableObject
{
    public float TimeBetweenSpawn;
    public List<Vector3> EnemySpawnPoints;
}
