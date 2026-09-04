using UnityEngine;

// 적 이동 스크립트 

public abstract class EnemyMove : MonoBehaviour
{
    private Vector2 _direction = Vector2.down;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    protected abstract void Move();
}