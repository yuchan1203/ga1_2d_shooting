using UnityEngine;
// 폭탄 스크립트 
public class Bomb : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    [SerializeField] private int _bombDamage;
    [SerializeField] private GameObject _bombEffectPrefab;
    private void Start()
    {
        Destroy(gameObject, _destroyTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (_bombEffectPrefab != null)
            {
                Instantiate(_bombEffectPrefab, transform.position, Quaternion.identity);
            }
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_bombDamage);
            }
            gameObject.SetActive(false);
        }
    }
}