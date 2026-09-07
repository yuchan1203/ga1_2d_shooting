using System;
using UnityEngine;

// 키보드 입력에 따라서 플레이어 이동을 처리하는 스크립트

public class PlayerMove : MonoBehaviour
{
    private Animator _animator;

    private PlayerSpeedControl _playerSpeedControl;
    [SerializeField] private float wrapBoundaryX;
    [SerializeField] private float maxPositionY;
    [SerializeField] private float minPositionY;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        var pos = transform.position;
        pos.x = 0;
        pos.y = -4;
        transform.position = pos;
        _playerSpeedControl = GetComponent<PlayerSpeedControl>();
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
        _animator.SetInteger("x", (int)direction.x);
        transform.position += (Vector3)direction * _playerSpeedControl.PlayerSpeed * Time.deltaTime;
        var pos = transform.position;
        if (pos.y < minPositionY) pos.y = minPositionY;
        if (pos.y > maxPositionY) pos.y = maxPositionY;
        if (pos.x < wrapBoundaryX * -1) pos.x = wrapBoundaryX;
        if (pos.x > wrapBoundaryX) pos.x = wrapBoundaryX * -1;
        transform.position = pos;
    }
}