using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Vector2 direction = Vector2.down;

    private void Update()
    {
        transform.Translate(direction * 1f * Time.deltaTime);
    }
}