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
            SpeedUp(1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpeedDown(1);
        }
    }
    public void SpeedUp(float value)
    {
        PlayerSpeed += value;
    }
    public void SpeedDown(float value)
    {
        PlayerSpeed -= value;
    }
}