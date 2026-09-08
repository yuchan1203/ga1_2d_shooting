using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    private void Update()
    {
        transform.Translate(Vector2.up * (_bulletSpeed * Time.deltaTime));
    }
}