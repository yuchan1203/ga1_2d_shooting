using UnityEngine;
// 적 스크립트 
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected int _damage;
    [SerializeField] private GameObject _deathEffectPrefab;
    [SerializeField] private GameObject _attackEffectPrefab;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public virtual void Init(Transform targetPlayer) { }
    public void TakeDamage(int bulletDamage)
    {
        _animator.SetTrigger("hit");
        _health -= bulletDamage;
        if (_health <= 0)
        {
            if (ItemSpawner.Instance != null)
            {
                ItemSpawner.Instance.SpawnItem(transform.position);
            }
            if (_deathEffectPrefab != null)
            {
                Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
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
}