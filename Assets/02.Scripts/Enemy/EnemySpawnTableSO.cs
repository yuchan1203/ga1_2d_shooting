using UnityEngine;

// 적 프리팹과 스폰 확률을 하드코딩하지 않게 해주는 스크립트

[System.Serializable]
public struct EnemySpawnData
{
    public string EnemyName;
    public GameObject Prefab;
    public float SpawnWeight;
}

[CreateAssetMenu(fileName = "EnemySpawnTable", menuName = "Scriptable Objects/Enemy Spawn Table")]
public class EnemySpawnTableSO : ScriptableObject
{
    public EnemySpawnData[] SpawnList;

    public GameObject GetRandomEnemyPrefab()
    {
        if (SpawnList == null || SpawnList.Length == 0)
        {
            return null;
        }

        float totalWeight = 0f;
        foreach (var enemy in SpawnList)
        {
            totalWeight += enemy.SpawnWeight;
        }

        float randomValue = UnityEngine.Random.Range(0f, totalWeight);
        float currentSum = 0f;

        foreach (var enemy in SpawnList)
        {
            currentSum += enemy.SpawnWeight;
            if (randomValue <= currentSum)
            {
                return enemy.Prefab;
            }
        }

        return SpawnList[0].Prefab;
    }
}