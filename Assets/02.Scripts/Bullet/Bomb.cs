using UnityEngine;

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
            //Destroy(gameObject);
            Instantiate(_bombEffectPrefab, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<Enemy>().TakeDamage(_bombDamage);
        }
    }
}