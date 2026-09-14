using UnityEngine;

public class GetRandomEnemy : MonoBehaviour
{
    [SerializeField] private EnemySpawnTableSO _spawnTable;
    public GameObject GetRandomEnemyPrefab()
    {
        if (_spawnTable == null || _spawnTable.SpawnList == null || _spawnTable.SpawnList.Length == 0)
        {
            return null;
        }
        var spawnList = _spawnTable.SpawnList;
        float totalWeight = 0f;
        foreach (var enemy in spawnList)
        {
            totalWeight += enemy.SpawnWeight;
        }
        float randomValue = UnityEngine.Random.Range(0f, totalWeight);
        float currentSum = 0f;
        foreach (var enemy in spawnList)
        {
            currentSum += enemy.SpawnWeight;
            if (randomValue <= currentSum)
            {
                return enemy.Prefab;
            }
        }
        return spawnList[0].Prefab;
    }
}