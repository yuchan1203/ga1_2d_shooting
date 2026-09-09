using UnityEngine;
// 플레이어를 바라보고 직선으로 이동하는 강한 적 스크립트 
public class StrongEnemy : Enemy
{
    private Vector2 _direction;
    private Transform _targetPlayer;
    public override void Init(Transform targetPlayer)
    {
        _targetPlayer = targetPlayer;
    }
    private void Start()
    {
        if (_targetPlayer == null) return;
        _direction = (_targetPlayer.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
    }
    protected override void Move()
    {
        transform.Translate(_direction * (_moveSpeed * Time.deltaTime));
    }
}