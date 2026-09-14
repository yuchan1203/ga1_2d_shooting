using UnityEngine;
public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet[] _bulletPrefabs;
    [SerializeField] private int _poolSize;
    private Bullet[,] _pool;
    private static BulletPool _instance = null;
    public static BulletPool Instance => _instance;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        _pool = new Bullet[_bulletPrefabs.Length, _poolSize];
        for (int i = 0; i < _bulletPrefabs.Length; i++)
        {
            Bullet bulletPrefab = _bulletPrefabs[i];
            // 창고 크기 만큼 총알을 미리 만들어서 집어 넣는다.
            for (int j = 0; j < _poolSize; j++)
            {
                Bullet bullet = Instantiate(bulletPrefab, gameObject.transform);
                bullet.gameObject.SetActive(false);
                _pool[i, j] = bullet;
            }
        }
    }
    public Bullet GetBullet(BulletType bulletType)
    {
        for (int i = 0; i < _pool.GetLength(0); i++)
        {
            if (_pool[i, 0].Type != bulletType)
            {
                continue;
            }
            for (int j = 0; j < _pool.GetLength(1); j++)
            {
                Bullet bullet = _pool[i, j];
                if (bullet.gameObject.activeSelf == false)
                {
                    bullet.gameObject.SetActive(true);
                    bullet.OnSpawn();
                    return bullet;
                }
            }
        }
        return null;
    }
}