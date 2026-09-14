using UnityEngine;
using UnityEngine.UI;
// 버튼을 클릭하면 플레이어의 자동 이동과 공격을 토글하는 스크립트 
public class UI_AutoButton : MonoBehaviour
{
    private bool _automode = false;
    private Player _player;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    [SerializeField] private AnimationCurve _bumpCurve;
    private Image _myImage;
    private bool _isBumping = false;
    private float _elapsedTime = 0;
    private float _bumpDuration = 0.3f;
    private float _bumpScale = 1.1f;
    private void Start()
    {
        _myImage = GetComponent<Image>();
        _player = GameObject.FindAnyObjectByType<Player>();
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
    public void AutoToggle()
    {
        _automode = !_automode;
        _player.GetComponent<PlayerAttack>().SetAuto(_automode);
        _player.GetComponent<PlayerMove>().enabled = !_automode;
        _player.GetComponent<PlayerAutoMove>().enabled = _automode;
        _myImage.sprite = _automode ? _onSprite : _offSprite;
        AudioManager.Instance.PlayUIButtonClicked();
    }
}