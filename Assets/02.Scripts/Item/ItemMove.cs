using UnityEngine;
// 아이템의 이동 스크립트 
public class ItemMove : MonoBehaviour
{
    private Player _player;
    [SerializeField] private float _delayTime = 1f;
    [SerializeField] private float _moveSpeed;
    private void Start()
    {
        _player = FindFirstObjectByType<Player>();
    }
    private void Timer()
    {
        _delayTime -= Time.deltaTime;
    }
    private void ItemMoveToPlayer()
    {
        Vector2 direction = (_player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
        transform.Translate(direction * (_moveSpeed * Time.deltaTime));
    }
    private void Update()
    {
        if (_delayTime > 0)
        {
            Timer();
        }
        else
        {
            ItemMoveToPlayer();
        }
    }
}