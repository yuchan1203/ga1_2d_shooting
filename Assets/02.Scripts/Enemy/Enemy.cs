using UnityEngine;
// 적 스크립트 
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] protected float _moveSpeed = 1f;
    [SerializeField] protected float _chanceOfItem = 10f;
    [SerializeField] protected int _damage = 10;
    [SerializeField] private GameObject _deathEffectPrefab;
    [SerializeField] private GameObject _attackEffectPrefab;
    [Header("Damage Fire Effect")]
    [SerializeField] private ParticleSystem _fireParticlePrefab;
    private int _maxHealth;
    private Animator _animator;
    private ParticleSystem _spawnedFireParticle;
    private ParticleSystem[] _childParticles;
    private float[] _baseEmissionRates;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _maxHealth = _health;
        if (_fireParticlePrefab != null)
        {
            _spawnedFireParticle = Instantiate(_fireParticlePrefab, transform);
            _spawnedFireParticle.transform.localPosition = Vector3.zero;
            _childParticles = _spawnedFireParticle.GetComponentsInChildren<ParticleSystem>();
            _baseEmissionRates = new float[_childParticles.Length];
            for (int i = 0; i < _childParticles.Length; i++)
            {
                _baseEmissionRates[i] = _childParticles[i].emission.rateOverTime.constant;
                var emission = _childParticles[i].emission;
                emission.rateOverTime = 0f;
            }
        }
    }
    public virtual void Init(Transform targetPlayer) { }
    public void TakeDamage(int bulletDamage)
    {
        _health -= bulletDamage;
        if (_health <= 0)
        {
            ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
            scoreManager.AddScore(100);
            if (ItemSpawner.Instance != null && Random.value <= (_chanceOfItem / 100))
            {
                ItemSpawner.Instance.SpawnItem(transform.position);
            }
            if (_deathEffectPrefab != null)
            {
                Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
            }
            if (AudioManager.Instance.EnemyDeadSound != null)
            {
                AudioManager.Instance.PlayEnemyDeadSound();
            }
            Destroy(gameObject);
        }
        else
        {
            UpdateFireEffect();
            _animator.SetTrigger("Hit");
            if (AudioManager.Instance.EnemyHitSound != null)
            {
                AudioManager.Instance.PlayEnemyHitSound();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Player player = other.GetComponentInParent<Player>();
        if (player != null)
        {
            player.TakeDamage(_damage);
        }
        if (_attackEffectPrefab != null)
        {
            Instantiate(_attackEffectPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    protected abstract void Move();
    private void Update()
    {
        Move();
    }
    private void UpdateFireEffect()
    {
        if (_fireParticlePrefab == null) return;
        float damageRatio = 1f - Mathf.Clamp01((float)_health / _maxHealth);
        for (int i = 0; i < _childParticles.Length; i++)
        {
            var emission = _childParticles[i].emission;
            emission.rateOverTime = damageRatio * _baseEmissionRates[i];
        }
    }
}