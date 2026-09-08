using System;
using UnityEngine;

// 키보드 입력에 따라서 플레이어 이동을 처리하는 스크립트

public class PlayerMove : MonoBehaviour
{
    private Animator _animator;

    private PlayerSpeedControl _playerSpeedControl;
    [SerializeField] private float _wrapBoundaryX;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;

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
        // todo: _playerSpeedControl이 없을 경우 고려해 방어 코드 추가하기 
        transform.position += (Vector3)direction * _playerSpeedControl.PlayerSpeed * Time.deltaTime;
        var pos = transform.position;
        if (pos.y < _minPositionY) pos.y = _minPositionY;
        if (pos.y > _maxPositionY) pos.y = _maxPositionY;
        if (pos.x < _wrapBoundaryX * -1) pos.x = _wrapBoundaryX;
        if (pos.x > _wrapBoundaryX) pos.x = _wrapBoundaryX * -1;
        transform.position = pos;
    }
}