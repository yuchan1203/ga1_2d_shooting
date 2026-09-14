using UnityEngine;
// 
[CreateAssetMenu(fileName = "EnemySpawnTable", menuName = "Scriptable Objects/Enemy Spawn Table")]
public class EnemySpawnTableSO : ScriptableObject
{
    public EnemySpawnData[] SpawnList;
}