using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float BulletSpeed;
    public float DestroyTime;

    private Vector2 direction = Vector2.up;

    private void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    private void Update()
    {
        transform.Translate(direction * BulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            EnemyMain enemy = collision.gameObject.GetComponent<EnemyMain>();
            enemy.EnemyHealth -= 40;
            if (enemy.EnemyHealth <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}