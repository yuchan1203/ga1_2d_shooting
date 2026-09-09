using UnityEngine;
// 적이 죽으면 30% 확률로 아이템을 소환하는 스크립트 
public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner Instance { get; private set; }
    [SerializeField] private float _chanceOfItem = 0.3f;
    [SerializeField] private ItemSpawnTableSO _spawnTable;
    private float _randomX;
    private int _randomItem;
    private Vector2 _vector2;
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SpawnItem(Vector2 position)
    {
        GameObject selectedPrefab = _spawnTable.GetRandomItemPrefab();
        if (selectedPrefab == null || Random.value > _chanceOfItem) return;
        Instantiate(selectedPrefab, position, Quaternion.identity);
    }
}