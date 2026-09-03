using UnityEngine;

public class BulletMain : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    [SerializeField] private int _bulletDamage;

    private void Start()
    {
        Destroy(gameObject, _destroyTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            EnemyMain enemy = collision.gameObject.GetComponent<EnemyMain>();
            enemy.TakeDamage(_bulletDamage);
        }
    }
}