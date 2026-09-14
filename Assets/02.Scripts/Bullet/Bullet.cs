using UnityEngine;
// 총알 스크립트 
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _destroyTime = 3f;
    [SerializeField] private int _bulletDamage;
    [SerializeField] private GameObject _bulletEffectPrefab;
    [SerializeField] private BulletType _type;
    public BulletType Type => _type;

    public void OnSpawn()
    {
        CancelInvoke(nameof(Deactivate));
        if (_destroyTime > 0f)
        {
            Invoke(nameof(Deactivate), _destroyTime);
        }
    }

    public void Deactivate()
    {
        CancelInvoke(nameof(Deactivate));
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Deactivate));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (_bulletEffectPrefab != null)
            {
                Instantiate(_bulletEffectPrefab, transform.position, Quaternion.identity);
            }

            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_bulletDamage);
            }

            Deactivate();
        }
    }
}