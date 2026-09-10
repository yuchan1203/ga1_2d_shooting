using UnityEngine;
// 닿는 모든 오브젝트를 삭제 
public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}