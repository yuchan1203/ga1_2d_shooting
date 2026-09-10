using UnityEngine;

public class EnemyVFX : MonoBehaviour
{
    [SerializeField] private GameObject _deathEffectPrefab;
    [SerializeField] private GameObject _attackEffectPrefab;
    [Header("Damage Fire Effect")]
    [SerializeField] private ParticleSystem _fireParticlePrefab;

    private Animator _animator;
    private HealthComponent _health;
    private ParticleSystem _spawnedFireParticle;
    private ParticleSystem[] _childParticles;
    private float[] _baseEmissionRates;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<HealthComponent>();

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

    private void OnEnable()
    {
        if (_health == null) return;
        _health.OnDamaged += HandleDamaged;
        _health.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
        if (_health == null) return;
        _health.OnDamaged -= HandleDamaged;
        _health.OnDeath -= HandleDeath;
    }

    private void HandleDamaged(int damage) => HitEffect();
    private void HandleDeath() => DeathEffect();

    public void HitEffect()
    {
        UpdateFireEffect();
        if (_animator != null) _animator.SetTrigger("Hit");
        if (AudioManager.Instance.EnemyHitSound != null)
        {
            AudioManager.Instance.PlayEnemyHitSound();
        }
    }

    public void AttackEffect()
    {
        if (_attackEffectPrefab != null)
        {
            Instantiate(_attackEffectPrefab, transform.position, Quaternion.identity);
        }
    }

    private void DeathEffect()
    {
        if (_deathEffectPrefab != null)
        {
            Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
        }
        if (AudioManager.Instance.EnemyDeadSound != null)
        {
            AudioManager.Instance.PlayEnemyDeadSound();
        }
    }

    private void UpdateFireEffect()
    {
        if (_fireParticlePrefab == null || _health == null) return;
        float damageRatio = 1f - _health.HealthRatio;
        for (int i = 0; i < _childParticles.Length; i++)
        {
            var emission = _childParticles[i].emission;
            emission.rateOverTime = damageRatio * _baseEmissionRates[i];
        }
    }
}