using UnityEngine;
using UnityEngine.UI;
// 버튼을 클릭하면 플레이어의 자동 이동과 공격을 토글하는 스크립트 
public class UI_AutoButton : MonoBehaviour
{
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    private bool _autoMode = false;
    private Player _player;
    private Image _myImage;
    private void Start()
    {
        _myImage = GetComponent<Image>();
        _player = GameObject.FindAnyObjectByType<Player>();
        AutoToggle();
    }
    public void AutoToggle()
    {
        _autoMode = !_autoMode;
        _player.GetComponent<PlayerAttack>().SetAuto(_autoMode);
        _player.GetComponent<PlayerMove>().enabled = !_autoMode;
        _player.GetComponent<PlayerAutoMove>().enabled = _autoMode;
        _myImage.sprite = _autoMode ? _onSprite : _offSprite;
        AudioManager.Instance.PlayUIButtonClicked();
    }
}