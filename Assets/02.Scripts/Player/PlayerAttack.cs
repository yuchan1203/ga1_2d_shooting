using UnityEngine;
// 스페이스바를 누를 때마다 총알을 생성해서 발사시키는 스크립트 
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] _bulletPrefabs;
    [SerializeField] private Transform[] _firePoints;
    [SerializeField] private GameObject _bombPrefab;
    public Transform LeftFirePoint;
    public Transform RightFirePoint;
    public Transform SubLeftFirePoint;
    public Transform SubRightFirePoint;
    private float _coolDownTime = 0.5f;
    private float _coolDown = 0;
    private bool _isAutoMode = false;
    private int _bomb = 0;
    public bool AutoFireMode => _isAutoMode;

    public void SetAuto(bool auto)
    {
        _isAutoMode = auto;
    }

    public void GetBomb(int var)
    {
        _bomb += var;
    }

    private void CoolDownTimer()
    {
        if (_coolDown > 0) _coolDown -= Time.deltaTime;
    }

    private void Fire()
    {
        if (BulletPool.Instance == null)
        {
            return;
        }

        SpawnBullet(BulletType.Main, LeftFirePoint);
        SpawnBullet(BulletType.Main, RightFirePoint);
        SpawnBullet(BulletType.Sub, SubLeftFirePoint);
        SpawnBullet(BulletType.Sub, SubRightFirePoint);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayPlayerShootSound();
        }
        _coolDown = _coolDownTime;
    }

    private void SpawnBullet(BulletType type, Transform firePoint)
    {
        if (firePoint == null)
        {
            return;
        }

        Bullet bullet = BulletPool.Instance.GetBullet(type);
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
        }
    }
    private void UseBomb()
    {
        Instantiate(_bombPrefab, _firePoints[0].position, _firePoints[0].rotation);
    }
    private void PlayerAttacking()
    {
        if (_coolDown <= 0)
        {
            if (_isAutoMode)
            {
                Fire();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }
        if (Input.GetKeyDown(KeyCode.B) && _bomb > 0)
        {
            UseBomb();
        }
    }
    private void Check1Num()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _isAutoMode = !_isAutoMode;
        }
    }
    private void Update()
    {
        CoolDownTimer();
        PlayerAttacking();
        Check1Num();
    }
    public void CoolDownUpgrade(float var)
    {
        _coolDownTime -= var;
        if (_coolDownTime < 0)
        {
            _coolDownTime = 0;
        }
    }
    public void CoolDownDowngrade(float var)
    {
        _coolDownTime += var;
        if (_coolDownTime > 1)
        {
            _coolDownTime = 1;
        }
    }
}