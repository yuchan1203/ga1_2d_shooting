using UnityEngine;
// 보스 적 스크립트 
public class BossEnemy : Enemy
{
    private Transform _targetPlayer;
    public override void Init(Transform targetPlayer)
    {
        _targetPlayer = targetPlayer;
    }
    private void Start()
    {
        if (AudioManager.Instance.EnemyHitSound != null)
        {
            AudioManager.Instance.PlayBossSummonSound();
        }
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