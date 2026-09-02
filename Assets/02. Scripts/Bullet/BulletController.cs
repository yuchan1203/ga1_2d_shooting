using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float BulletSpeed;
    Vector2 direction = Vector2.up;

    private void Update()
    {
        transform.Translate(direction * BulletSpeed * Time.deltaTime);
    }
}