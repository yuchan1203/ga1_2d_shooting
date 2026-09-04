using UnityEngine;

// 적 스크립트 

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected int damage;

    public void TakeDamage(int bulletDamage)
    {
        health -= bulletDamage;
        Debug.Log($"Enemy HP:{health}");
        if (health <= 0)
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
            player.TakeDamage(damage);
        }

        Destroy(this.gameObject);
    }

    protected abstract void Move();

    private void Update()
    {
        Move();
    }
}