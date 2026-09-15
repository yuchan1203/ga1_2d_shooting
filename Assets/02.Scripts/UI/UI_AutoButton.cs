using UnityEngine;
using UnityEngine.UI;
public class UI_AutoButton : MonoBehaviour
{
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    private bool _autoMode = false;
    private Image _myImage;
    private Player _player;
    private PlayerAttack _playerAttack;
    private PlayerMove _playerMove;
    private PlayerAutoMove _playerAutoMove;
    private void Start()
    {
        _myImage = GetComponent<Image>();
        _autoMode = false;
    }
    public void AutoToggle()
    {
        _autoMode = !_autoMode;
        RefreshPlayerReferences();
        ApplyAutoMode();
        AudioManager.Instance?.PlayUIButtonClicked();
    }
    private void RefreshPlayerReferences()
    {
        _player = FindFirstObjectByType<Player>();
        _playerAttack = null;
        _playerMove = null;
        _playerAutoMove = null;
        if (_player != null && _player.gameObject != null)
        {
            _playerAttack = _player.GetComponent<PlayerAttack>();
            _playerMove = _player.GetComponent<PlayerMove>();
            _playerAutoMove = _player.GetComponent<PlayerAutoMove>();
        }
    }
    private void ApplyAutoMode()
    {
        if (_playerAttack != null) _playerAttack.SetAuto(_autoMode);
        if (_playerMove != null) _playerMove.enabled = !_autoMode;
        if (_playerAutoMove != null) _playerAutoMove.enabled = _autoMode;
        if (_myImage != null) _myImage.sprite = _autoMode ? _onSprite : _offSprite;
    }
}