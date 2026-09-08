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
            // todo: Enemy 클래스가 ItemSpawner.Instance에 직접 의존하고 있어 결합도가 높습니다.
            // Enemy 사망 시 이벤트를 발생시키고, ItemSpawner가 이 이벤트를 구독하여 아이템을 생성하도록 변경하여 결합도를 낮추십시오.
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