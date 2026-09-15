using UnityEngine;
// 
[CreateAssetMenu(fileName = "EnemySpawnTable", menuName = "Scriptable Objects/Enemy Spawn Table")]
public class EnemySpawnTableSO : ScriptableObject
{
    [SerializeField] private EnemySpawnData[] _spawnList;
    public EnemySpawnData[] SpawnList => _spawnList;
}