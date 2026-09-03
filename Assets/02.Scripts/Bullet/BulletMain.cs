using UnityEngine;

public class BulletMain : MonoBehaviour
{
    public float DestroyTime;
    public int BulletDamage;

    private void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            EnemyMain enemy = collision.gameObject.GetComponent<EnemyMain>();
            enemy.EnemyHealth -= BulletDamage;
            Debug.Log($"Enemy HP:{enemy.EnemyHealth}");
            if (enemy.EnemyHealth <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}