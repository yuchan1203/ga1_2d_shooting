using UnityEngine;
public class PlayerAutoMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private GameObject _target = null;
    private static GameObject[] _cachedEnemies;
    private void FindTarget()
    {
        if (_target != null) return;
        if (_cachedEnemies == null || _cachedEnemies.Length == 0)
        {
            _cachedEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
        if (_cachedEnemies.Length == 0) return;
        float minDistance = float.MaxValue;
        foreach (GameObject enemy in _cachedEnemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                _target = enemy;
            }
        }
    }
    private void Move()
    {
        if (_target == null)
        {
            return;
        }
        Vector3 diff = _target.transform.position - transform.position;
        Vector3 direction = diff.normalized;
        if (diff.y >= 3)
        {
            direction.y = 1;
        }
        else
        {
            direction.y = -1;
        }
        direction.Normalize();
        transform.position += direction * (_speed * Time.deltaTime);
    }
    private void Update()
    {
        FindTarget();
        Move();
    }
}