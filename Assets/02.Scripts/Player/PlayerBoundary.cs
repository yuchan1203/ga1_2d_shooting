using UnityEngine;
// 플레이어 이동을 제한하는 스크립트 
public class PlayerBoundary : MonoBehaviour
{
    [SerializeField] private float _wrapBoundaryX;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;
    private void Start()
    {
        transform.position = new Vector3(0f, -4f, 0f);
    }
    private void Update()
    {
        var pos = transform.position;
        if (pos.y < _minPositionY) pos.y = _minPositionY;
        if (pos.y > _maxPositionY) pos.y = _maxPositionY;
        if (pos.x < _wrapBoundaryX * -1)
        {
            pos.x = _wrapBoundaryX;
        }
        if (pos.x > _wrapBoundaryX)
        {
            pos.x = _wrapBoundaryX * -1;
        }
        transform.position = pos;
    }
}