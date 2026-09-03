using UnityEngine;

public enum EnemyType
{
    NormalEnemy,
    AheadEnemy,
    AttackEnemy
}

public class EnemyMain : MonoBehaviour
{
    public int EnemyHealth = 100;
    public EnemyType Type = EnemyType.NormalEnemy;

    private void Start()
    {
    }

    private void Update()
    {
    }
}