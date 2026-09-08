using UnityEngine;

// 적 스크립트 

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected int _damage;
    private Animator _animator;
    [SerializeField] private GameObject _deathEffectPrefab;
    [SerializeField] private GameObject _attackEffectPrefab;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int bulletDamage)
    {
        _animator.SetTrigger("hit");
        _health -= bulletDamage;
        Debug.Log($"Enemy HP:{_health}");
        if (_health <= 0)
        {
            // todo: 싱글톤 객체에 의존하고 있는 문제를 수정해 결합도 낮추기 
            ItemSpawner.Instance.SpawnItem(transform.position);
            Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(_damage);
        }
        Instantiate(_attackEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    protected abstract void Move();

    private void Update()
    {
        Move();
    }
}