using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float BulletSpeed;

    private Vector2 direction = Vector2.up;

    private void Update()
    {
        transform.Translate(direction * BulletSpeed * Time.deltaTime);
    }
}