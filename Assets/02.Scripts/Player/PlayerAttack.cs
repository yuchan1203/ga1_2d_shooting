using UnityEngine;

// 스페이스바를 누를 때마다 총알을 생성해서 발사시키는 스크립트 

public class PlayerAttack : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject ExtraBulletPrefab;
    public Transform FirePointLeft;
    public Transform FirePointRight;
    public Transform ExtraFirePointLeft;
    public Transform ExtraFirePointRight;
    public float CoolDownTime { get; private set; } = 0.5f;
    private float _coolDown = 0;
    private bool _isAutoMode = false;

    private void CoolDownTimer()
    {
        if (_coolDown > 0) _coolDown -= Time.deltaTime;
    }

    private void Fire()
    {
        Instantiate(BulletPrefab, FirePointLeft.position, FirePointLeft.rotation);
        Instantiate(BulletPrefab, FirePointRight.position, FirePointRight.rotation);
        Instantiate(ExtraBulletPrefab, ExtraFirePointLeft.position, ExtraFirePointLeft.rotation);
        Instantiate(ExtraBulletPrefab, ExtraFirePointRight.position, ExtraFirePointRight.rotation);
        _coolDown = CoolDownTime;
    }

    private void PlayerAttacking()
    {
        if (_coolDown <= 0)
        {
            if (_isAutoMode)
                Fire();
            else if (Input.GetKeyDown(KeyCode.Space)) Fire();
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

    public void ChangeCoolDown(float coolDown)
    {
        CoolDownTime += coolDown;
        if (CoolDownTime <= 0)
        {
            CoolDownTime = 0;
        }
    }
}