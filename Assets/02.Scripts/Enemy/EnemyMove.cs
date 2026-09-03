using System;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Vector2 direction = Vector2.down;
    private EnemyMain _enemyMain;

    private void Start()
    {
        _enemyMain = GetComponent<EnemyMain>();
        if (_enemyMain.Type == EnemyType.NormalEnemy)
        {
        }
        else if (_enemyMain.Type == EnemyType.AheadEnemy)
        {
        }
        else if (_enemyMain.Type == EnemyType.AttackEnemy)
        {
        }
    }

    private void Update()
    {
        transform.Translate(direction * 1f * Time.deltaTime);
    }
}