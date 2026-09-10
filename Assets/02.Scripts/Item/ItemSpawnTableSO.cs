using UnityEngine;
// 아이템 프리팹과 스폰 확률을 하드코딩하지 않게 해주는 스크립트
[System.Serializable]
public struct ItemSpawnData
{
    public string ItemName;
    public GameObject Prefab;
    public float SpawnWeight;
}
[CreateAssetMenu(fileName = "ItemSpawnTable", menuName = "Scriptable Objects/Item Spawn Table")]
public class ItemSpawnTableSO : ScriptableObject
{
    public ItemSpawnData[] SpawnList;
    public GameObject GetRandomItemPrefab()
    {
        if (SpawnList == null || SpawnList.Length == 0)
        {
            return null;
        }
        float totalWeight = 0f;
        foreach (var item in SpawnList)
        {
            totalWeight += item.SpawnWeight;
        }
        float randomValue = UnityEngine.Random.Range(0f, totalWeight);
        float currentSum = 0f;
        foreach (var item in SpawnList)
        {
            currentSum += item.SpawnWeight;
            if (randomValue <= currentSum)
            {
                return item.Prefab;
            }
        }
        return SpawnList[0].Prefab;
    }
}