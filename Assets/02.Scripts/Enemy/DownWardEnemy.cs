using UnityEngine;

public class DownWardEnemy : EnemyMain
{
    protected override void Move()
    {
        transform.Translate(direction * 1f * Time.deltaTime);
    }


    private void Start()
    {
    }

    private void Update()
    {
    }
}