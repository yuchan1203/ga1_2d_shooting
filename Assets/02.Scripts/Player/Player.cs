using UnityEngine;

// 플레이어 스크립트 

public class Player : MonoBehaviour
{
    public int Health { get; private set; } = 50;
    // todo: 데미지를 입었을 때 피격 효과 재생시키기 
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Heal(int hp)
    {
        Health += hp;
    }
}