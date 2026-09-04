using UnityEngine;

// 규칙에 따라 적을 소환하는 스크립트 

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnTableSO spawnTable;

    // 시간
    [SerializeField] private float respawnTime = 5f;

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
        GameObject selectedPrefab = spawnTable.GetRandomEnemyPrefab();
        if (selectedPrefab != null)
        {
            Instantiate(selectedPrefab, transform.position, Quaternion.identity);
        }

        _respawnTimer = respawnTime;
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