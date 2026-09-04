using UnityEngine;

// 규칙에 따라 적을 소환하는 스크립트 

public class EnemySpawner : MonoBehaviour
{
    // 스폰할 적 프리팹 리스트 
    [SerializeField] private Enemy[] EnemyPrefabs;

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
                Instantiate(EnemyPrefabs[0], _vector2, Quaternion.identity);
            }
            else if (randomEnemy == 2)
            {
                Instantiate(EnemyPrefabs[1], _vector2, Quaternion.identity);
            }
            else if (randomEnemy == 3)
            {
                Instantiate(EnemyPrefabs[2], _vector2, Quaternion.identity);
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