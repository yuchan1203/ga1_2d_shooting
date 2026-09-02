using UnityEngine;
// 스페이스바를 누를 때마다 총알을 생성해서 발사시키는 스크립트 
public class PlayerAttack : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform FirePoint;
    public float CoolDownTime;
    private float CoolDown = 0;
    
    private void Start()
    {
        Vector3 pos = FirePoint.position;
        transform.position = pos;
    }

    private void Update()
    {
        if (CoolDown > 0)
        {
            CoolDown -= Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            CoolDown = CoolDownTime;
        }
    }
}