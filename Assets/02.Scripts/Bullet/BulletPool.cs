using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet[] _bulletPrefabs;
    [SerializeField] private int _poolSize = 30;

    private readonly Dictionary<BulletType, List<Bullet>> _pool = new Dictionary<BulletType, List<Bullet>>();
    private readonly Dictionary<BulletType, Bullet> _prefabMap = new Dictionary<BulletType, Bullet>();

    private static BulletPool _instance = null;
    public static BulletPool Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<BulletPool>();
                if (_instance == null)
                {
                    Debug.LogError("[BulletPool] 씬에 BulletPool 오브젝트가 존재하지 않습니다! 하이어라키에서 빈 GameObject를 생성하고 BulletPool 컴포넌트를 부착해주세요.");
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

        InitializePool();
    }

    private void InitializePool()
    {
        if (_bulletPrefabs == null || _bulletPrefabs.Length == 0)
        {
            Debug.LogError("[BulletPool] _bulletPrefabs 배열이 비어 있습니다! 인스펙터에서 Bullet 프리팹을 할당해주세요.");
            return;
        }

        foreach (Bullet prefab in _bulletPrefabs)
        {
            if (prefab == null)
            {
                Debug.LogWarning("[BulletPool] _bulletPrefabs 요소 중 null인 항목이 있습니다. 인스펙터를 확인해주세요.");
                continue;
            }

            BulletType type = prefab.Type;
            if (_prefabMap.ContainsKey(type))
            {
                Debug.LogWarning($"[BulletPool] 중복된 BulletType({type}) 프리팹이 등록되어 있습니다.");
                continue;
            }

            _prefabMap[type] = prefab;
            _pool[type] = new List<Bullet>(_poolSize);

            for (int i = 0; i < _poolSize; i++)
            {
                Bullet bullet = CreateBullet(prefab);
                _pool[type].Add(bullet);
            }
        }
    }

    private Bullet CreateBullet(Bullet prefab)
    {
        Bullet bullet = Instantiate(prefab, transform);
        bullet.gameObject.SetActive(false);
        return bullet;
    }

    public Bullet GetBullet(BulletType bulletType)
    {
        if (!_pool.TryGetValue(bulletType, out List<Bullet> bulletList))
        {
            Debug.LogError($"[BulletPool] {bulletType} 타입의 총알 풀이 초기화되지 않았습니다. 인스펙터의 프리팹 등록 상태를 확인해주세요.");
            return null;
        }

        for (int i = 0; i < bulletList.Count; i++)
        {
            Bullet bullet = bulletList[i];
            if (bullet != null && !bullet.gameObject.activeSelf)
            {
                bullet.gameObject.SetActive(true);
                bullet.OnSpawn();
                return bullet;
            }
        }

        // 모든 총알이 사용 중일 때 동적으로 추가 생성하여 발사 누락 방지
        if (_prefabMap.TryGetValue(bulletType, out Bullet prefab) && prefab != null)
        {
            Bullet newBullet = CreateBullet(prefab);
            bulletList.Add(newBullet);
            newBullet.gameObject.SetActive(true);
            newBullet.OnSpawn();
            return newBullet;
        }

        return null;
    }
}