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
    //[SerializeField] private float _maxEmissionRate = 50f;
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
            _spawnedFireParticle.transform.localPosition = Vector3.zero; // 적의 위치에 맞춤
            _childParticles = _spawnedFireParticle.GetComponentsInChildren<ParticleSystem>();
            _baseEmissionRates = new float[_childParticles.Length];
            for (int i = 0; i < _childParticles.Length; i++)
            {
                // 각 파티클 시스템의 기존 rateOverTime 수치를 기록하고 0으로 초기화
                _baseEmissionRates[i] = _childParticles[i].emission.rateOverTime.constant;
                var emission = _childParticles[i].emission;
                emission.rateOverTime = 0f;
            }
        }
        //Debug.Log($"_maxHealth: {_maxHealth},  health: {_health}");
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
    // #region agent log
    protected void AgentDebugLog(string hypothesisId, string location, string message, string dataJson)
    {
        try
        {
            string path = System.IO.Path.GetFullPath(Application.dataPath + "/../debug-8c06bb.log");
            long ts = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            System.IO.File.AppendAllText(path,
                "{\"sessionId\":\"8c06bb\",\"hypothesisId\":\"" + hypothesisId + "\",\"location\":\"" + location + "\",\"message\":\"" + message + "\",\"timestamp\":" + ts + ",\"data\":" + dataJson + "}\n");
        }
        catch { }
    }
    protected string AgentAnimDebugJson()
    {
        var sr = GetComponent<SpriteRenderer>();
        var an = GetComponent<Animator>();
        string clip = "none";
        string ctrl = "none";
        if (an != null && an.runtimeAnimatorController != null)
        {
            ctrl = an.runtimeAnimatorController.name;
            var inf = an.GetCurrentAnimatorClipInfo(0);
            if (inf != null && inf.Length > 0 && inf[0].clip != null) clip = inf[0].clip.name;
        }
        string sprite = sr != null && sr.sprite != null ? sr.sprite.name : "null";
        Vector3 e = transform.eulerAngles;
        Vector3 p = transform.position;
        return "{\"type\":\"" + GetType().Name + "\",\"clip\":\"" + clip + "\",\"controller\":\"" + ctrl + "\",\"sprite\":\"" + sprite + "\",\"flipY\":" + (sr != null && sr.flipY ? "true" : "false") + ",\"eulerZ\":" + e.z.ToString("F2") + ",\"posX\":" + p.x.ToString("F3") + ",\"posY\":" + p.y.ToString("F3") + "}";
    }
    // #endregion
    private void UpdateFireEffect()
    {
        if (_fireParticlePrefab == null) return;
        float damageRatio = 1f - Mathf.Clamp01((float)_health / _maxHealth);
        // 모든 하위 파티클 시스템의 방출량을 각자의 초기 비율대로 증가
        for (int i = 0; i < _childParticles.Length; i++)
        {
            var emission = _childParticles[i].emission;
            emission.rateOverTime = damageRatio * _baseEmissionRates[i];
        }
    }
}