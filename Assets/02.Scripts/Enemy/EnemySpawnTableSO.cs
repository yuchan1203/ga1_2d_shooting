using UnityEngine;

// 적 프리팹과 스폰 확률을 하드코딩하지 않게 해주는 스크립트

[System.Serializable]
public struct EnemySpawnData
{
    public string enemyName;
    public GameObject prefab;
    public float spawnWeight;
}

[CreateAssetMenu(fileName = "EnemySpawnTable", menuName = "Scriptable Objects/Enemy Spawn Table")]
public class EnemySpawnTableSO : ScriptableObject
{
    public EnemySpawnData[] spawnList;

    public GameObject GetRandomEnemyPrefab()
    {
        if (spawnList == null || spawnList.Length == 0)
        {
            return null;
        }

        float totalWeight = 0f;
        foreach (var enemy in spawnList)
        {
            totalWeight += enemy.spawnWeight;
        }

        float randomValue = UnityEngine.Random.Range(0f, totalWeight);
        float currentSum = 0f;

        foreach (var enemy in spawnList)
        {
            currentSum += enemy.spawnWeight;
            if (randomValue <= currentSum)
            {
                return enemy.prefab;
            }
        }

        return spawnList[0].prefab;
    }
}