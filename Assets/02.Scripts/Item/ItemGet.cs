using UnityEngine;
public class ItemGet : MonoBehaviour
{
    [SerializeField] private GameObject _getItemPrefab;
    [SerializeField] private ItemType _type;
    [SerializeField] private float _value;
    public ItemType Type => _type;
    public float Value => _value;
    private Player _player;
    private PlayerAttack _playerAttack;
    private PlayerSpeedControl _playerSpeedControl;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_player == null) _player = other.GetComponentInParent<Player>();
        if (_player == null) return;
        switch (_type)
        {
            case ItemType.PlayerHeal:
                _player.Heal((int)_value);
                break;
            case ItemType.MoveSpeedUp:
                if (_playerSpeedControl == null) _playerSpeedControl = other.GetComponentInParent<PlayerSpeedControl>();
                _playerSpeedControl?.SpeedUp(_value);
                break;
            case ItemType.FireRateUp:
                if (_playerAttack == null) _playerAttack = other.GetComponentInParent<PlayerAttack>();
                _playerAttack?.CoolDownUpgrade(_value);
                break;
            case ItemType.BulletDamageUp:
                if (_playerAttack == null) _playerAttack = other.GetComponentInParent<PlayerAttack>();
                _playerAttack?.AddBulletDamage(_value);
                break;
            case ItemType.GetBomb:
                if (_playerAttack == null) _playerAttack = other.GetComponentInParent<PlayerAttack>();
                _playerAttack?.GetBomb((int)_value > 0 ? (int)_value : 1);
                break;
            case ItemType.GetCoin:
                _player.AddCoin((int)_value > 0 ? (int)_value : 1);
                break;
        }
        if (_getItemPrefab != null)
        {
            Instantiate(_getItemPrefab, transform.position, Quaternion.identity);
        }
        AudioManager.Instance?.PlayGetItemSound();
        Destroy(gameObject);
    }
}