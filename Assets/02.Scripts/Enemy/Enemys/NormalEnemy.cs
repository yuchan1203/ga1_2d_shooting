using UnityEngine;

// 아래쪽으로 이동하는 적 스크립트 

public class NormalEnemy : Enemy
{
    protected override void Move()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * (_moveSpeed * Time.deltaTime));
    }
}