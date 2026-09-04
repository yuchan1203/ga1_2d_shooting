using UnityEngine;

// 플레이어를 바라보고 플레이어 쪽으로 이동하는 적 스크립트

public class HomingEnemy : Enemy
{
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    protected override void Move()
    {
        if (_player == null)
        {
            return;
        }

        Vector2 direction = _player.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}