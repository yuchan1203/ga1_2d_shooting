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
    // #region agent log
    private int _agentLogFrames;
    // #endregion
    private void Start()
    {
        if (_targetPlayer == null) return;
        _direction = (_targetPlayer.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
        // #region agent log
        Vector3 up = transform.up;
        float align = Vector2.Dot(_direction, new Vector2(up.x, up.y));
        AgentDebugLog("B", "StrongEnemy.cs:Start", "strong-aim",
            "{\"runId\":\"post-fix\",\"dirX\":" + _direction.x.ToString("F3") + ",\"dirY\":" + _direction.y.ToString("F3") + ",\"upX\":" + up.x.ToString("F3") + ",\"upY\":" + up.y.ToString("F3") + ",\"dotDirVsUp\":" + align.ToString("F3") + ",\"anim\":" + AgentAnimDebugJson() + "}");
        // #endregion
    }
    protected override void Move()
    {
        Vector3 before = transform.position;
        transform.Translate(_direction * (_moveSpeed * Time.deltaTime), Space.World);
        // #region agent log
        if (_agentLogFrames < 4)
        {
            Vector3 delta = transform.position - before;
            Vector2 d2 = new Vector2(delta.x, delta.y);
            float vsDir = d2.sqrMagnitude > 0.0000001f ? Vector2.Dot(d2.normalized, _direction) : 0f;
            float vsUp = d2.sqrMagnitude > 0.0000001f ? Vector2.Dot(d2.normalized, (Vector2)transform.up) : 0f;
            AgentDebugLog("C", "StrongEnemy.cs:Move", "strong-move",
                "{\"runId\":\"post-fix\",\"dx\":" + delta.x.ToString("F4") + ",\"dy\":" + delta.y.ToString("F4") + ",\"dotVsWorldDir\":" + vsDir.ToString("F3") + ",\"dotVsLocalUp\":" + vsUp.ToString("F3") + ",\"anim\":" + AgentAnimDebugJson() + "}");
        }
        _agentLogFrames++;
        // #endregion
    }
}