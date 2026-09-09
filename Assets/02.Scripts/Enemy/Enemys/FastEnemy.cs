using UnityEngine;
// 아래쪽으로 빠르게 이동하는 적 스크립트 
public class FastEnemy : Enemy
{
    // #region agent log
    private int _agentLogFrames;
    // #endregion
    private void Start()
    {
        // Sprite forward is authored along local +Y; face the player (down) without using local Translate.
        transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        // #region agent log
        AgentDebugLog("A", "FastEnemy.cs:Start", "fast-start",
            "{\"runId\":\"post-fix\",\"anim\":" + AgentAnimDebugJson() + "}");
        // #endregion
    }
    protected override void Move()
    {
        Vector2 direction = Vector2.down;
        Vector3 before = transform.position;
        transform.Translate(direction * (_moveSpeed * Time.deltaTime), Space.World);
        // #region agent log
        if (_agentLogFrames < 4)
        {
            Vector3 delta = transform.position - before;
            AgentDebugLog("A", "FastEnemy.cs:Move", "fast-move",
                "{\"runId\":\"post-fix\",\"dx\":" + delta.x.ToString("F4") + ",\"dy\":" + delta.y.ToString("F4") + ",\"spaceSelf\":false,\"anim\":" + AgentAnimDebugJson() + "}");
        }
        _agentLogFrames++;
        // #endregion
    }
}