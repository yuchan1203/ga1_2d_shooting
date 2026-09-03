using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject NormalEnemyPrefab;
    public GameObject AheadEnemyPrefab;
    public GameObject AttackEnemyPrefab;
    public float RespawnTime = 5;
    private float RespawnTimer = 0;
    private float randomX;
    private int randomEnemy;
    private Vector2 _vector2;

    private void CoolDownTimer()
    {
        if (RespawnTimer > 0) RespawnTimer -= Time.deltaTime;
    }

    private void EnemySpawn()
    {
        if (RespawnTimer <= 0)
        {
            randomX = Random.Range(-2.0f, 2.0f);
            _vector2 = new Vector2(randomX, 5);
            randomEnemy = Random.Range(1, 4);
            if (randomEnemy == 1)
            {
                Instantiate(NormalEnemyPrefab, _vector2, Quaternion.identity);
            }
            else if (randomEnemy == 2)
            {
                Instantiate(AheadEnemyPrefab, _vector2, Quaternion.identity);
            }
            else if (randomEnemy == 3)
            {
                Instantiate(AttackEnemyPrefab, _vector2, Quaternion.identity);
            }

            RespawnTimer = RespawnTime;
        }
    }

    private void Update()
    {
        CoolDownTimer();
        EnemySpawn();
    }
}