using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType Type;
    public float Value;
    private GameObject _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _delayTime = 1f;
    // todo: Item 클래스가 아이템의 타입 정보, 효과 적용 로직, 이동 로직(추적) 등 너무 많은 책임을 담당하고 있습니다.
    // 특히 아이템 종류(ItemType)가 늘어날 때마다 switch 문이 커지는 구조입니다.
    // 전략 패턴(Strategy Pattern)을 사용하여 아이템 효과 적용 로직을 분리하고,
    // Item 클래스는 아이템의 기본 동작(이동, 수집 처리)만 담당하도록 개선을 검토하십시오.
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
        // todo: 플레이어가 아이템을 먹을 때 획득 이펙트 추가하기
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
            // todo: Update()에서 매 프레임 _player의 위치를 참조하기 위해 Start()에서 태그로 찾은 게임 오브젝트를 사용합니다.
            // 플레이어가 파괴되거나 태그가 변경되는 등의 예외 상황에 대한 처리가 부족하며, 매 프레임 위치를 계산하는 비용이 발생합니다.
            // 플레이어의 위치를 Update에서 매번 구하기보다, 플레이어의 위치를 참조할 수 있는 프로퍼티를 제공하거나 이벤트를 통해 정보를 전달받는 구조를 고려하십시오.
            Vector2 direction = _player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
            direction.Normalize();
            transform.Translate(direction * (_moveSpeed * Time.deltaTime));
        }
    }
}