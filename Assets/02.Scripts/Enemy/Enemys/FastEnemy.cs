using UnityEngine;
// 아래쪽으로 빠르게 이동하는 적 스크립트 
public class FastEnemy : Enemy
{
    private void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 180f);
    }
    protected override void Move()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * (_moveSpeed * Time.deltaTime), Space.World);
    }
}