using UnityEngine;

// 스페이스바를 누를 때마다 총알을 생성해서 발사시키는 스크립트 

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletPrefabs;
    [SerializeField] private Transform[] firePoints;
    public float CoolDownTime { get; private set; } = 0.5f;
    private float _coolDown = 0;
    private bool _isAutoMode = false;

    private void CoolDownTimer()
    {
        if (_coolDown > 0) _coolDown -= Time.deltaTime;
    }

    private void Fire()
    {
        Instantiate(bulletPrefabs[0], firePoints[0].position, firePoints[0].rotation);
        Instantiate(bulletPrefabs[0], firePoints[1].position, firePoints[1].rotation);
        Instantiate(bulletPrefabs[1], firePoints[2].position, firePoints[2].rotation);
        Instantiate(bulletPrefabs[1], firePoints[3].position, firePoints[3].rotation);
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