using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType Type;
    public float Value;

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
}