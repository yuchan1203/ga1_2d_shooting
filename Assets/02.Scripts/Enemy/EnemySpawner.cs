using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject NormalEnemyPrefab;
    public GameObject AheadEnemyPrefab;
    public GameObject AttackEnemyPrefab;
    public float RespawnTime = 5;
    private float RespawnTimer = 0;
    private Vector2 _vector2 = new Vector2(0, 5);

    private void CoolDownTimer()
    {
        if (RespawnTimer > 0) RespawnTimer -= Time.deltaTime;
    }

    private void EnemySpawn()
    {
        if (RespawnTimer <= 0)
        {
            Instantiate(NormalEnemyPrefab, _vector2, Quaternion.identity);
            RespawnTimer = RespawnTime;
        }
    }


    private void Update()
    {
        CoolDownTimer();
        EnemySpawn();
    }
}