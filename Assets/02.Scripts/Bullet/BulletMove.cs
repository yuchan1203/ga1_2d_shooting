using UnityEngine;
// 총알의 이동 스크립트 
public class BulletMove : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    private void Update()
    {
        transform.Translate(Vector2.up * (_bulletSpeed * Time.deltaTime));
    }
}