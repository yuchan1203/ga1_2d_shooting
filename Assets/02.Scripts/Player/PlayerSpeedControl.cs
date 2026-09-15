using UnityEngine;
// 키보드 입력에 따라서 플레이어의 이동 속도를 결정하는 스크립트 
public class PlayerSpeedControl : MonoBehaviour
{
    public float PlayerSpeed { get; private set; } = 5f;
    private void Update()
    {
        SpeedControl();
    }
    private void SpeedControl()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpeedUp(1f);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpeedDown(1f);
        }
    }
    public void SpeedUp(float value)
    {
        PlayerSpeed = Mathf.Max(PlayerSpeed + value, 0f);
    }
    public void SpeedDown(float value)
    {
        PlayerSpeed = Mathf.Max(PlayerSpeed - value, 0f);
    }
}