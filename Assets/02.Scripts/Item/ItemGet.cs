using UnityEngine;
// 아이템의 획득 스크립트 
public class ItemGet : MonoBehaviour
{
    [SerializeField] private GameObject _getItemPrefab;
    public ItemType Type;
    public float Value;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponentInParent<Player>();
        if (player == null) return;
        switch (Type)
        {
            case ItemType.PlayerHeal:
                {
                    player.Heal((int)Value);
                    Debug.Log($"플레이어 체력: {player.Health}");
                    break;
                }
            case ItemType.MoveSpeedUp:
                {
                    PlayerSpeedControl playerSpeedControl = other.GetComponentInParent<PlayerSpeedControl>();
                    if (playerSpeedControl == null) return;
                    playerSpeedControl.SpeedUp(Value);
                    Debug.Log($"플레이어 이동속도: {playerSpeedControl.PlayerSpeed}");
                    break;
                }
            case ItemType.FireRateUp:
                {
                    PlayerAttack playerAttack = other.GetComponentInParent<PlayerAttack>();
                    if (playerAttack == null) return;
                    playerAttack.CoolDownUpgrade(Value);
                    Debug.Log($"플레이어 발사속도: {playerAttack.CoolDownTime}");
                    break;
                }
            case ItemType.BulletDamageUp:
                {
                    //PlayerAttack playerAttack = other.GetComponentInParent<PlayerAttack>();
                    //if (playerAttack == null) return;
                    //playerAttack.ChangeCoolDown(Value);
                    //Debug.Log($"플레이어 총알 데미지: {playerAttack.CoolDownTime}");
                    break;
                }
            case ItemType.GetBomb:
                {
                    //PlayerAttack playerAttack = other.GetComponentInParent<PlayerAttack>();
                    //if (playerAttack == null) return;
                    //playerAttack.ChangeCoolDown(Value);
                    //Debug.Log($"플레이어 폭탄 개수: {playerAttack.CoolDownTime}");
                    break;
                }
            case ItemType.GetCoin:
                {
                    //PlayerAttack playerAttack = other.GetComponentInParent<PlayerAttack>();
                    //if (playerAttack == null) return;
                    //playerAttack.ChangeCoolDown(Value);
                    //Debug.Log($"플레이어 코인 개수: {playerAttack.CoolDownTime}");
                    break;
                }
        }
        if (_getItemPrefab != null)
        {
            Instantiate(_getItemPrefab, transform.position, Quaternion.identity);
        }
        AudioManager.Instance.PlayGetItemSound();
        Destroy(gameObject);
    }
}