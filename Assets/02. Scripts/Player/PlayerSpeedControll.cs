using UnityEngine;

public class PlayerSpeedControll : MonoBehaviour
{
    public float PlayerSpeed;
    
    private void Update()
    {
        SpeedControll();
    }
    
    private void SpeedControll()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerSpeed += 5;
            Debug.Log("Speed: " + PlayerSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerSpeed -= 5;
            Debug.Log("Speed: " + PlayerSpeed);
        }
    }
    
}