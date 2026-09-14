using UnityEngine;
using UnityEngine.UI;
// 버튼 클릭 효과 재사용하는 스크립트 
public class UI_ButtonClick : MonoBehaviour
{
    [SerializeField] private AnimationCurve _bumpCurve;
    private Button _button;
    private bool _isBumping = false;
    private float _elapsedTime = 0;
    private float _bumpDuration = 0.1f;
    private float _bumpScale = 1.1f;
    private void Start()
    {
        _button.onClick.AddListener(PlayAnimation);
    }
    public void PlayAnimation()
    {
        _isBumping = true;
        _elapsedTime = 0;
    }
    private void Update()
    {
        if (!_isBumping) return;
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _bumpDuration)
        {
            transform.localScale = Vector3.one;
            _isBumping = false;
            return;
        }
        float time = _elapsedTime / _bumpDuration;
        float curveValue = _bumpCurve.Evaluate(time);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * _bumpScale, curveValue);
    }
}