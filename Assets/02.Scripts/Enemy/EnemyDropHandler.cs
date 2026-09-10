using UnityEngine;

public class EnemyDropHandler : MonoBehaviour
{
    [SerializeField] private float _chanceOfItem = 10f;

    private HealthComponent _health;

    private void Awake()
    {
        _health = GetComponent<HealthComponent>();
    }

    private void OnEnable()
    {
        if (_health == null) return;
        _health.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
        if (_health == null) return;
        _health.OnDeath -= HandleDeath;
    }

    private void HandleDeath()
    {
        ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
        if (scoreManager != null) scoreManager.AddScore(100);

        if (ItemSpawner.Instance != null && Random.value <= (_chanceOfItem / 100f))
        {
            ItemSpawner.Instance.SpawnItem(transform.position);
        }

        Destroy(gameObject);
    }
}