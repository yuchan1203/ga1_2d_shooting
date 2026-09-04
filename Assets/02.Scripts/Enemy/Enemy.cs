using UnityEngine;

// 적 스크립트 

public enum EnemyType
{
    NormalEnemy,
    AheadEnemy,
    AttackEnemy
}

public class Enemy : MonoBehaviour
{
    public int EnemyHealth = 100;
    public EnemyType Type { get; private set; } = EnemyType.NormalEnemy;

    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
        Debug.Log($"Enemy HP:{EnemyHealth}");
        if (EnemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}