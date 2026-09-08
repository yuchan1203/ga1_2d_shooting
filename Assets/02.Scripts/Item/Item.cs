using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType Type;
    public float Value;
    private GameObject _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _delayTime = 1f;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        Player player = other.GetComponent<Player>();
        PlayerSpeedControl playerSpeedControl = other.GetComponent<PlayerSpeedControl>();
        PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();

        if (player == null)
        {
            Debug.LogWarning("플레이어 태그 오브젝트에 player 컴포넌트가 없습니다.");
            return;
        }

        if (playerSpeedControl == null)
        {
            Debug.LogWarning("플레이어 태그 오브젝트에 playerSpeedControl 컴포넌트가 없습니다.");
            return;
        }

        if (playerAttack == null)
        {
            Debug.LogWarning("플레이어 태그 오브젝트에 playerAttack 컴포넌트가 없습니다.");
            return;
        }

        switch (Type)
        {
            case ItemType.Heal:
                {
                    player.Heal((int)Value);
                    Debug.Log($"플레이어 체력: {player.Health}");
                    break;
                }
            case ItemType.MoveSpeedUp:
                {
                    playerSpeedControl.ChangeSpeed(Value);
                    Debug.Log($"플레이어 이동속도: {playerSpeedControl.PlayerSpeed}");
                    break;
                }
            case ItemType.FireRateUp:
                {
                    playerAttack.ChangeCoolDown(Value);
                    Debug.Log($"플레이어 발사속도: {playerAttack.CoolDownTime}");
                    break;
                }
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        if (_delayTime > 0)
        {
            _delayTime -= Time.deltaTime;
        }
        else
        {
            Vector2 direction = _player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
            direction.Normalize();
            transform.Translate(direction * (_moveSpeed * Time.deltaTime));
        }
    }
}