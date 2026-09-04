using UnityEngine;

// 키보드 입력에 따라서 플레이어의 이동 속도를 결정하는 스크립트 

public class PlayerSpeedControll : MonoBehaviour
{
    public float PlayerSpeed { get; private set; } = 5f;

    private void Update()
    {
        SpeedControll();
    }

    private void SpeedControll()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeSpeed(1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeSpeed(-1);
        }
    }

    public void ChangeSpeed(float changeSpeed)
    {
        PlayerSpeed += changeSpeed;
        Debug.Log("Speed: " + PlayerSpeed);
    }
}