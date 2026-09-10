using UnityEngine;
public class PlayerAutoMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Update()
    {
        // 타겟 구하기
        GameObject target = GameObject.FindWithTag("Enemy");
        if (target == null) return;
        // 방향 구하기
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        // 이동하기 
        direction.y = 0;
        transform.position += direction * _speed * Time.deltaTime;
    }
}