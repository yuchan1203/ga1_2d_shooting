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
            Instantiate(_bombEffectPrefab, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<Enemy>().TakeDamage(_bombDamage);
        }
    }
}