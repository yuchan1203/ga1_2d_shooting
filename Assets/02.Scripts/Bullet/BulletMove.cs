using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private void Update()
    {
        transform.Translate(Vector2.up * (bulletSpeed * Time.deltaTime));
    }
}