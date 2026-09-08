using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    [SerializeField] private int _bulletDamage;
    [SerializeField] private GameObject _bulletEffectPrefab;

    private void Start()
    {
        Destroy(gameObject, _destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(_bulletEffectPrefab, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<Enemy>().TakeDamage(_bulletDamage);
        }
    }
}