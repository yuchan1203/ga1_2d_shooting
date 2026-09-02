using UnityEngine;
// 스페이스바를 누를 때마다 총알을 생성해서 발사시키는 스크립트 
public class PlayerAttack : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform FirePoint;
    public float CoolDownTime;
    private float CoolDown = 0;
    private bool isAutoMode = false;
    
    private void Start()
    {
        Vector3 pos = FirePoint.position;
        transform.position = pos;
    }

    private void CoolDownTimer()
    {
        if (CoolDown > 0)
        {
            CoolDown -= Time.deltaTime;
        }
    }
    
    private void PlayerAttacking()
    {
        if (CoolDown <= 0)
        {
            if (isAutoMode)
            {
                Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
                CoolDown = CoolDownTime;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
                CoolDown = CoolDownTime;
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