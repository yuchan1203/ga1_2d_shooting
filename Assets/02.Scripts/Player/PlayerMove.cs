using System;
using UnityEngine;

// 키보드 입력에 따라서 플레이어 이동을 처리하는 스크립트

public class PlayerMove : MonoBehaviour
{
    private PlayerSpeedControll _playerSpeedControll;

    private void Start()
    {
        var pos = transform.position;
        pos.x = 0;
        pos.y = -4;
        transform.position = pos;
        _playerSpeedControll = GetComponent<PlayerSpeedControll>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        var direction = new Vector2(h, v).normalized;
        transform.position += (Vector3)direction * _playerSpeedControll.PlayerSpeed * Time.deltaTime;
        var pos = transform.position;
        if (pos.y < -4.7f) pos.y = -4.7f;
        if (pos.y > -2f) pos.y = -2f;
        if (pos.x < -3.5f) pos.x = 3.4f;
        if (pos.x > 3.5f) pos.x = -3.4f;
        transform.position = pos;
    }
}