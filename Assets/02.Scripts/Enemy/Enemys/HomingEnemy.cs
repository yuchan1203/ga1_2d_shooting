using UnityEngine;
public class HomingEnemy : Enemy
{
    private Transform _targetPlayer;
    public override void Init(Transform targetPlayer)
    {
        _targetPlayer = targetPlayer;
    }
    protected override void Move()
    {
        if (_targetPlayer == null) return;
        Vector2 direction = (_targetPlayer.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
        transform.Translate(direction * (_moveSpeed * Time.deltaTime), Space.World);
    }
}