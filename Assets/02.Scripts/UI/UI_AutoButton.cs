using UnityEngine;
using UnityEngine.UI;
// 버튼을 클릭하면 플레이어의 자동 이동과 공격을 토글하는 스크립트 
public class UI_AutoButton : MonoBehaviour
{
    private bool _automode = false;
    private Player _player;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    private Image _myImage;
    private void Start()
    {
        _myImage = GetComponent<Image>();
        _player = GameObject.FindAnyObjectByType<Player>();
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