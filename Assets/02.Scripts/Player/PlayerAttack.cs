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
    public float CoolDownTime;
    private float CoolDown = 0;
    private bool isAutoMode = false;

    private void CoolDownTimer()
    {
        if (CoolDown > 0)
        {
            CoolDown -= Time.deltaTime;
        }
    }

    private void Fire()
    {
        Instantiate(BulletPrefab, FirePointLeft.position, FirePointLeft.rotation);
        Instantiate(BulletPrefab, FirePointRight.position, FirePointRight.rotation);
        Instantiate(ExtraBulletPrefab, ExtraFirePointLeft.position, ExtraFirePointLeft.rotation);
        Instantiate(ExtraBulletPrefab, ExtraFirePointRight.position, ExtraFirePointRight.rotation);
        CoolDown = CoolDownTime;
    }

    private void PlayerAttacking()
    {
        if (CoolDown <= 0)
        {
            if (isAutoMode)
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isAutoMode = !isAutoMode;
        }
    }

    private void Update()
    {
        CoolDownTimer();
        PlayerAttacking();
        Check1Num();
    }
}