using System;
using UnityEngine;
// 키보드 입력에 따라서 플레이어 이동을 처리하는 스크립트
public class PlayerMove : MonoBehaviour
{
    private PlayerSpeedControll playerSpeedControll;
    
    private void Start()
    {
        Vector3 pos = transform.position;
        pos.x = 0;
        pos.y = -4;
        transform.position = pos;
        playerSpeedControll = GetComponent<PlayerSpeedControll>();
    }
    
    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(h, v).normalized;
        transform.position += (Vector3)direction * playerSpeedControll.PlayerSpeed * Time.deltaTime;
        Vector3 pos = transform.position;
        if (pos.y < -4.7f)
        {
            pos.y = -4.7f;
        }
        if (pos.y > -2f)
        {
            pos.y = -2f;
        }
        if (pos.x < -3f)
        {
            pos.x = 2.9f;
        }
        if (pos.x > 3f)
        {
            pos.x = -3f;
        }
        transform.position = pos;
    }
    
}