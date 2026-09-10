using System;
using UnityEngine;

// 체력이 있는 오브젝트의 피격과 회복 및 체력 관리 스크립트
public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 50;
    private int _currentHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;
    public float HealthRatio => (float)_currentHealth / _maxHealth;

    public event Action<int> OnDamaged; // 인자: 받은 데미지량
    public event Action OnDeath;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_currentHealth <= 0) return;

        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDeath?.Invoke();
        }
        else
        {
            OnDamaged?.Invoke(damage);
        }
    }

    public void HealHP(int healAmount)
    {
        _currentHealth = Mathf.Min(_currentHealth + healAmount, _maxHealth);
    }
}