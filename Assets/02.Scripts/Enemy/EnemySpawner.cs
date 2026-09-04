using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // 스폰할 적 프리팹
    [SerializeField] private EnemyMain _normalEnemyPrefab;
    [SerializeField] private EnemyMain _aheadEnemyPrefab;

    [SerializeField] private EnemyMain _attackEnemyPrefab;

    // 시간
    [SerializeField] private float _respawnTime = 5f;
    private float _respawnTimer = 0f;

    private float randomX;
    private int randomEnemy;
    private Vector2 _vector2;

    private void CoolDownTimer()
    {
        if (_respawnTimer > 0) _respawnTimer -= Time.deltaTime;
    }

    private void EnemySpawn()
    {
        if (_respawnTimer <= 0)
        {
            randomX = Random.Range(-2.0f, 2.0f);
            _vector2 = new Vector2(randomX, 5);
            randomEnemy = Random.Range(1, 4);
            if (randomEnemy == 1)
            {
                Instantiate(_normalEnemyPrefab, _vector2, Quaternion.identity);
            }
            else if (randomEnemy == 2)
            {
                Instantiate(_aheadEnemyPrefab, _vector2, Quaternion.identity);
            }
            else if (randomEnemy == 3)
            {
                Instantiate(_attackEnemyPrefab, _vector2, Quaternion.identity);
            }

            _respawnTimer = _respawnTime;
        }
    }

    private void Update()
    {
        CoolDownTimer();
        EnemySpawn();
    }
}