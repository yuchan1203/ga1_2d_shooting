using UnityEngine;
// 플레이어 스크립트 
public class Player : MonoBehaviour
{
    public int Health { get; private set; } = 50;
    [SerializeField] private GameObject _playerDeathPrefab;
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            if (_playerDeathPrefab != null)
            {
                Instantiate(_playerDeathPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
    // todo: Health 프로퍼티의 setter가 private으로 되어 있어 외부에서 직접 수정할 수 없지만,
    // Heal 메서드는 내부 체력 한계치에 대한 검증 로직이 없습니다.
    // TakeDamage와 Heal 메서드 내에서 체력의 최대/최소값 범위를 제한하는 로직을 추가하여 데이터의 무결성을 보장하십시오. 
    public void Heal(int hp)
    {
        Health += hp;
    }
}