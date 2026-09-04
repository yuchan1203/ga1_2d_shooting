using UnityEngine;

// 플레이어를 바라보고 직선으로 이동하는 적 스크립트 

public class AimedEnemy : Enemy
{
    private GameObject _player;
    private Vector2 _direction;


    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Debug.Log("플레이어 태그를 가진 게임 오브젝트를 찾지 못했습니다.");
            return;
        }

        _direction = _player.transform.position - transform.position;
        _direction.Normalize();
    }

    protected override void Move()
    {
        if (_player == null)
        {
            return;
        }

        transform.Translate(_direction * moveSpeed * Time.deltaTime);
    }
}