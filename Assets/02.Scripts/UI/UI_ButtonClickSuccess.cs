using UnityEngine;
using UnityEngine.UI;
// 버튼 클릭 효과 재사용하는 스크립트 
public class UI_ButtonClickSuccess : MonoBehaviour
{
    [SerializeField] private AnimationCurve _bumpCurve;

    private bool _isBumping;
    private float _elapsedTime;
    private const float BumpDuration = 0.1f;
    private const float BumpScale = 1.1f;

    public void PlaySuccessAnimation()
    {
        _isBumping = true;
        _elapsedTime = 0;
    }
    private void Update()
    {
        if (!_isBumping) return;
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > BumpDuration)
        {
            transform.localScale = Vector3.one;
            _isBumping = false;
            return;
        }
        float time = _elapsedTime / BumpDuration;
        float curveValue = _bumpCurve.Evaluate(time);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * BumpScale, curveValue);
    }
}