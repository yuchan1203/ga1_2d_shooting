using UnityEngine;
public class Player : MonoBehaviour
{
    public int Health { get; private set; } = 50;
    [SerializeField] private GameObject _playerDeathPrefab;
    [SerializeField] private int _maxHealth = 50;
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
            PlayerDeath();
        }
        else if (AudioManager.Instance != null)
        {
            AudioManager.Instance?.PlayPlayerHitSound();
        }
    }
    public void PlayerDeath()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance?.PlayPlayerDeadSound();
        }
        if (_playerDeathPrefab != null)
        {
            Instantiate(_playerDeathPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    public void Heal(int healAmount)
    {
        Health += healAmount;
        if (Health > _maxHealth)
        {
            Health = _maxHealth;
        }
    }
    public int Coin { get; private set; } = 0;
    public void AddCoin(int amount = 1)
    {
        if (amount <= 0) return;
        Coin += amount;
    }
    public bool UseCoin(int amount = 1)
    {
        if (amount <= 0) return false;
        if (Coin >= amount)
        {
            Coin -= amount;
            return true;
        }
        return false;
    }
}