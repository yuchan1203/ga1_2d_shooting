using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    [SerializeField] private int bulletDamage;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(bulletDamage);
        }
    }
}