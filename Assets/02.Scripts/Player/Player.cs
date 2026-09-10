using UnityEngine;
// 플레이어 스크립트 
public class Player : MonoBehaviour
{
    public int Health { get; private set; } = 50;
    [SerializeField] private GameObject _playerDeathPrefab;
    [SerializeField] private int _maxHealth = 100;
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            PlayerDeath();
        }
        else if (AudioManager.Instance.PlayerHitSound != null)
        {
            AudioManager.Instance.PlayPlayerHitSound();
        }
    }
    public void PlayerDeath()
    {
        if (AudioManager.Instance.PlayerDeadSound != null)
        {
            AudioManager.Instance.PlayPlayerDeadSound();
        }
        if (_playerDeathPrefab != null)
        {
            Instantiate(_playerDeathPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    public void Heal(int var)
    {
        Health += var;
        if (Health > _maxHealth)
        {
            Health = _maxHealth;
        }
    }
}