using UnityEngine;

// 적 스크립트 

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected int _damage;
    private Animator _animator;
    // todo: 적 피격 시 에니메이션 추가하기 
    // todo: 적 사망 시 에니메이션 추가하기
    // todo: 적이 플레이어에게 닿으면 공격력만큼 체력 줄이라고 하게 만들기 
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
            ItemSpawner.Instance.SpawnItem(transform.position);
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

        Destroy(this.gameObject);
    }

    protected abstract void Move();

    private void Update()
    {
        Move();
    }
}