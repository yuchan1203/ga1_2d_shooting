using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float BulletSpeed;
    public float DestroyTime;

    Vector2 direction = Vector2.up;

    private void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    private void Update()
    {
        transform.Translate(direction * BulletSpeed * Time.deltaTime);
    }
}