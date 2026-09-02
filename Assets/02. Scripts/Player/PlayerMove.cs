using System;
using UnityEngine;
// 키보드 입력에 따라서 플레이어 이동을 처리하는 스크립트

public class PlayerMove : MonoBehaviour
{
    // 필요 필드 
    public float Speed;
    private bool isRecording = true;
    private bool isReplaying = false;
    
    private void Start()
    {
        Vector3 pos = transform.position;
        pos.x = 0;
        pos.y = -4;
        transform.position = pos;
    }

    // 매 프레임마다 실행된다
    // 별다른 설정이 없을 경우 가능한 많이 프레임이 생성된다.
    private void Update()
    {
        Move();
        SpeedControll();
    }

    private void SpeedControll()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Speed += 5;
            Debug.Log("Speed: " + Speed);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed -= 5;
            Debug.Log("Speed: " + Speed);
        }
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal"); // 키보드 왼/오른쪽 입력 상태에 따라 -1f ~ 0 1f
        float v = Input.GetAxisRaw("Vertical"); // 키보드 위/아래 입력 상태에 따라 -1f ~ 0 1f
        
        //Debug.Log($"h:{h}, v:{v}");
        
        Vector2 direction = new Vector2(h, v);
        Vector2 normalizedSpeed = direction.normalized;
        transform.position += (Vector3)normalizedSpeed * Speed * Time.deltaTime;

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
        
        /*
        // 1. 키보드 입력을 받는다.
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("왼쪽 방향키를 누르는 중");
            // 2. 키보드 입력에 따라 방향을 구한다.
            // 게임에는 벡터라는 타입이 있다.
            // 벡터: 크기와 방향을 의미
            Vector2 direction1 = new Vector2(-1, 0); // 왼쪽 방향
            // Vector2 direction1 = Vector2.left; 같은 역할
            // 3. 방향과 속력에 따라 이동한다.
            // 속도: 방향 * 속력
            // 매직 넘버: 보는 사람에 따라 의미가 달라질 수 있는 헷갈리는 숫자
            transform.Translate(direction1 * Speed * Time.deltaTime);
            // deltaTime: 이전 프레임으로부터 지금 프레임까지 시간이 얼마나 지났는지 ms로 반환
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("오른쪽 방향키를 누르는 중");
            Vector2 direction2 = new Vector2(1, 0); // 오른쪽 방향
            transform.Translate(direction2 * Speed * Time.deltaTime);
        }
        */
    }
}