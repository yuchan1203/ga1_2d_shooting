using UnityEngine;
// 키보드 입력에 따라서 플레이어 이동을 처리하는 스크립트
public class PlayerMove : MonoBehaviour
{
    private Animator _animator;
    private PlayerSpeedControl _playerSpeedControl;
    [SerializeField] private TrailRenderer _trailRenderer;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
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
        if (v < 0)
        {
            _trailRenderer.emitting = false;
        }
        else
        {
            _trailRenderer.emitting = true;
        }
        var direction = new Vector2(h, v).normalized;
        _animator.SetInteger("x", (int)direction.x);
        if (_playerSpeedControl == null)
        {
            return;
        }
        transform.position += (Vector3)direction * _playerSpeedControl.PlayerSpeed * Time.deltaTime;
    }
}