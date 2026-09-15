using UnityEngine;
// 적 스크립트
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float MoveSpeed = 1f;
    [SerializeField] protected int Damage = 10;

    private HealthComponent _health;
    private EnemyVFX _vfx;

    private void Awake()
    {
        _health = GetComponent<HealthComponent>();
        _vfx = GetComponent<EnemyVFX>();
    }

    public virtual void Init(Transform targetPlayer) { }

    public void TakeDamage(int bulletDamage)
    {
        if (_health == null) return;
        _health.TakeDamage(bulletDamage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Player player = other.GetComponentInParent<Player>();
        if (player != null) player.TakeDamage(Damage);

        if (_vfx != null) _vfx.AttackEffect();

        Destroy(gameObject);
    }

    protected abstract void Move();

    private void Update()
    {
        Move();
    }
}