using UnityEngine;
// 버튼 클릭 실패 시 좌우로 흔들리는 효과를 부여하는 스크립트
public class UI_ButtonClickFail : MonoBehaviour
{
    [SerializeField] private AnimationCurve _shakeCurve;
    private bool _isShaking = false;
    private float _elapsedTime = 0;
    private Vector3 _initialPosition;

    private const float ShakeDuration = 0.2f;
    private const float ShakeMagnitude = 10f;

    private void Awake()
    {
        _initialPosition = transform.localPosition;
    }

    // 외부 스크립트에서 클릭 실패 시 1회 호출
    public void PlayFailAnimation()
    {
        _isShaking = true;
        _elapsedTime = 0;
        _initialPosition = transform.localPosition;
    }

    private void Update()
    {
        if (!_isShaking) return;

        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > ShakeDuration)
        {
            transform.localPosition = _initialPosition;
            _isShaking = false;
            return;
        }

        float time = _elapsedTime / ShakeDuration;
        float curveValue = (_shakeCurve != null && _shakeCurve.length > 0)
            ? _shakeCurve.Evaluate(time)
            : Mathf.Sin(time * Mathf.PI * 8f);

        transform.localPosition = _initialPosition + new Vector3(curveValue * ShakeMagnitude, 0, 0);
    }
}