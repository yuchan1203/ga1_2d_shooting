using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    [SerializeField] private int _bulletDamage;
    // todo: 총알 이미지 넣기 
    private void Start()
    {
        Destroy(gameObject, _destroyTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(_bulletDamage);
        }
    }
}