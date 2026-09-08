using UnityEngine;

// 적 스크립트 

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected int _damage;
    private Animator _animator;

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
            Destroy(this.gameObject);
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