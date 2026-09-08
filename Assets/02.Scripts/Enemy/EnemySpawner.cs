using UnityEngine;

// 규칙에 따라 적을 소환하는 스크립트 

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnTableSO _spawnTable;
    [SerializeField] private float _respawnTime = 5.0f;
    [SerializeField] private float _maxPositionX = 2.0f;

    private float _respawnTimer = 0f;
    private float _randomX;
    private int _randomEnemy;
    private Vector2 _vector2;

    private void CoolDownTimer()
    {
        if (_respawnTimer > 0) _respawnTimer -= Time.deltaTime;
    }

    private void Spawn()
    {
        GameObject selectedPrefab = _spawnTable.GetRandomEnemyPrefab();
        if (selectedPrefab != null)
        {
            float randomX = Random.Range(_maxPositionX * -1, _maxPositionX);
            Debug.Log($"{randomX}");
            Vector2 spawnPosition = new Vector2(randomX, transform.position.y);
            Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        }

        _respawnTimer = _respawnTime;
    }

    private void Update()
    {
        CoolDownTimer();
        if (_respawnTimer <= 0)
        {
            Spawn();
        }
    }
}