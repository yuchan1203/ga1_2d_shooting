using UnityEngine;

// 플레이어 스크립트 

public class Player : MonoBehaviour
{
    [SerializeField] private int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}