using UnityEngine;
// 스페이스바를 누를 때마다 총알을 생성해서 발사시키는 스크립트 
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] _bulletPrefabs;
    //[SerializeField] private Transform[] _firePoints;
    //[SerializeField] private GameObject _bombPrefab;
    public Transform LeftFirePoint;
    public Transform RightFirePoint;
    public Transform SubLeftFirePoint;
    public Transform SubRightFirePoint;
    private float _coolDownTime = 0.5f;
    private float _coolDown = 0;
    private bool _isAutoMode = false;
    private int _bomb = 0;
    public int Bomb => _bomb;

    [SerializeField] private float _bulletDamageUP = 0f;
    public float BulletDamageUP => _bulletDamageUP;

    public float CoolDownTime => _coolDownTime;

    public bool AutoFireMode => _isAutoMode;
    public void SetAuto(bool auto)
    {
        _isAutoMode = auto;
    }

    public void GetBomb(int var)
    {
        _bomb += var;
    }

    public void AddBulletDamage(float value)
    {
        _bulletDamageUP += value;
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
            bullet.SetBonusDamage(_bulletDamageUP);
        }
    }
    private void UseBomb()
    {
        if (_bomb <= 0) return;
        Transform firePoint = LeftFirePoint != null ? LeftFirePoint : transform;
        if (_bulletPrefabs != null && _bulletPrefabs.Length > 0 && _bulletPrefabs[0] != null)
        {
            Instantiate(_bulletPrefabs[0], firePoint.position, firePoint.rotation);
        }
        _bomb--;
    }
    private void PlayerAttacking()
    {
        if (_coolDown <= 0)
        {
            if (_isAutoMode)
            {
                Fire();
            }
            else if (SimpleInput.GetButton("Attack") || Input.GetKeyDown(KeyCode.Space))
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
        if (_coolDownTime < 0.05f)
        {
            _coolDownTime = 0.05f;
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