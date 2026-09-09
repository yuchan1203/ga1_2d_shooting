using UnityEngine;
// 배경 스크롤 스크립트 
public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 0.1f;
    private Material _material;
    private float _offsetY = 0f;
    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }
    private void Update()
    {
        _offsetY += _scrollSpeed * Time.deltaTime;
        _material.SetTextureOffset("_BaseMap", new Vector2(0, _offsetY));
    }
}