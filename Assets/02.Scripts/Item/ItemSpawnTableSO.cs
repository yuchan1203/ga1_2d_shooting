using UnityEngine;
// 아이템 프리팹과 스폰 확률을 하드코딩하지 않게 해주는 스크립트
[CreateAssetMenu(fileName = "ItemSpawnTable", menuName = "Scriptable Objects/Item Spawn Table")]
public class ItemSpawnTableSO : ScriptableObject
{
    [SerializeField] private ItemSpawnData[] _spawnList;
    public ItemSpawnData[] SpawnList => _spawnList;
    public GameObject GetRandomItemPrefab()
    {
        if (_spawnList == null || _spawnList.Length == 0)
        {
            return null;
        }
        float totalWeight = 0f;
        foreach (var item in _spawnList)
        {
            totalWeight += item.SpawnWeight;
        }
        float randomValue = UnityEngine.Random.Range(0f, totalWeight);
        float currentSum = 0f;
        foreach (var item in _spawnList)
        {
            currentSum += item.SpawnWeight;
            if (randomValue <= currentSum)
            {
                return item.Prefab;
            }
        }
        return _spawnList[0].Prefab;
    }
}