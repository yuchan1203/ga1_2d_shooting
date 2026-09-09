using UnityEngine;
// 스페이스바를 누를 때마다 총알을 생성해서 발사시키는 스크립트 
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] _bulletPrefabs;
    [SerializeField] private Transform[] _firePoints;
    public float CoolDownTime { get; private set; } = 0.5f;
    private float _coolDown = 0;
    private bool _isAutoMode = false;
    private void CoolDownTimer()
    {
        if (_coolDown > 0) _coolDown -= Time.deltaTime;
    }
    private void Fire()
    {
        // todo: 총알 유형을 명시적으로 구분하는 등의 방법을 사용해 매직넘버 제거 
        Instantiate(_bulletPrefabs[0], _firePoints[0].position, _firePoints[0].rotation);
        Instantiate(_bulletPrefabs[0], _firePoints[1].position, _firePoints[1].rotation);
        Instantiate(_bulletPrefabs[1], _firePoints[2].position, _firePoints[2].rotation);
        Instantiate(_bulletPrefabs[1], _firePoints[3].position, _firePoints[3].rotation);
        AudioManager.Instance.PlayPlayerShootSound();
        _coolDown = CoolDownTime;
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
    }
    private void Check1Num()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) _isAutoMode = !_isAutoMode;
    }
    private void Update()
    {
        CoolDownTimer();
        PlayerAttacking();
        Check1Num();
    }
    public void CoolDownUpgrade(float var)
    {
        CoolDownTime -= var;
        if (CoolDownTime < 0)
        {
            CoolDownTime = 0;
        }
    }
    public void CoolDownDowngrade(float var)
    {
        CoolDownTime += var;
        if (CoolDownTime > 1)
        {
            CoolDownTime = 1;
        }
    }
}