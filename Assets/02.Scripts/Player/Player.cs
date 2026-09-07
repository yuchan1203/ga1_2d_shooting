using UnityEngine;

// 플레이어 스크립트 

public class Player : MonoBehaviour
{
    public int Health { get; private set; } = 50;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}