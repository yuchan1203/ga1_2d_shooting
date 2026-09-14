using UnityEngine;
using UnityEngine.UI;
using TMPro;
// 하단 업그레이드 버튼 스크립트: 1코인을 차감하여 스탯을 강화하고 텍스트를 갱신
public class UI_UpgradeButton : MonoBehaviour
{
    [Header("업그레이드 설정")]
    [SerializeField] private UpgradeType _upgradeType = UpgradeType.AttackDamage;
    [SerializeField] private int _coinCost = 1;
    [Header("UI 텍스트 참조 (미할당 시 자식 오브젝트에서 자동 탐색)")]
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private TextMeshProUGUI _scoreCostText;
    private Button _button;
    private Player _player;
    private PlayerAttack _playerAttack;
    private PlayerSpeedControl _playerSpeedControl;
    private UI_ButtonClickSuccess _uiButtonClickSuccess;
    private UI_ButtonClickFail _uiButtonClickFail;
    private int _level = 1;
    private void Awake()
    {
        _button = GetComponent<Button>();
        if (_button != null)
        {
            _button.onClick.AddListener(OnClickUpgrade);
        }
        // 인스펙터 미할당 시 자식 오브젝트 자동 탐색
        if (_titleText == null)
        {
            _titleText = transform.Find("TitleText")?.GetComponent<TextMeshProUGUI>();
        }
        if (_valueText == null)
        {
            _valueText = transform.Find("ValueText")?.GetComponent<TextMeshProUGUI>();
        }
        if (_scoreCostText == null)
        {
            _scoreCostText = transform.Find("ScoreCostText")?.GetComponent<TextMeshProUGUI>();
        }
    }
    private void Start()
    {
        InitPlayerReferences();
        UpdateUI();
    }
    private void InitPlayerReferences()
    {
        if (_player == null)
        {
            _player = FindFirstObjectByType<Player>();
        }
        if (_player != null)
        {
            if (_playerAttack == null)
            {
                _playerAttack = _player.GetComponent<PlayerAttack>();
            }
            if (_playerSpeedControl == null)
            {
                _playerSpeedControl = _player.GetComponent<PlayerSpeedControl>();
            }
        }
    }
    public void OnClickUpgrade()
    {
        AudioManager.Instance.PlayUIButtonClicked();
        InitPlayerReferences();
        if (_player == null)
        {
            Debug.LogWarning("[UI_UpgradeButton] Player를 찾을 수 없습니다.");
            _uiButtonClickFail = GetComponent<UI_ButtonClickFail>();
            _uiButtonClickFail.PlayFailAnimation();
            return;
        }
        // 1코인 차감 시도
        if (!_player.UseCoin(_coinCost))
        {
            Debug.Log("[UI_UpgradeButton] 코인이 부족합니다.");
            _uiButtonClickFail = GetComponent<UI_ButtonClickFail>();
            _uiButtonClickFail.PlayFailAnimation();
            return;
        }
        _uiButtonClickSuccess = GetComponent<UI_ButtonClickSuccess>();
        _uiButtonClickSuccess.PlaySuccessAnimation();
        // 타입에 따른 스탯 증가
        switch (_upgradeType)
        {
            case UpgradeType.AttackDamage:
                {
                    if (_playerAttack != null)
                    {
                        _playerAttack.AddBulletDamage(0.5f);
                    }

                    break;
                }
            case UpgradeType.AttackSpeed:
                {
                    if (_playerAttack != null)
                    {
                        _playerAttack.CoolDownUpgrade(0.01f);
                    }

                    break;
                }
            case UpgradeType.MoveSpeed:
                {
                    if (_playerSpeedControl != null)
                    {
                        _playerSpeedControl.SpeedUp(0.5f);
                    }
                    break;
                }
            case UpgradeType.All:
                {
                    if (_playerAttack != null)
                    {
                        _playerAttack.AddBulletDamage(0.5f);
                        _playerAttack.CoolDownUpgrade(0.05f);
                    }
                    if (_playerSpeedControl != null)
                    {
                        _playerSpeedControl.SpeedUp(0.5f);
                    }
                    break;
                }
        }
        _level++;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayUIButtonClicked();
        }
        UpdateUI();
    }
    public void UpdateUI()
    {
        InitPlayerReferences();
        // 1. TitleText 갱신
        if (_titleText != null)
        {
            switch (_upgradeType)
            {
                case UpgradeType.AttackDamage:
                    {
                        _titleText.text = $"공격력 LV.{_level}";
                        break;
                    }
                case UpgradeType.AttackSpeed:
                    {
                        _titleText.text = $"공격속도 LV.{_level}";
                        break;
                    }
                case UpgradeType.MoveSpeed:
                    {
                        _titleText.text = $"이동속도 LV.{_level}";
                        break;
                    }
                case UpgradeType.All:
                    {
                        _titleText.text = $"전체 강화 LV.{_level}";
                        break;
                    }
            }
        }
        // 2. ValueText 갱신
        if (_valueText != null)
        {
            switch (_upgradeType)
            {
                case UpgradeType.AttackDamage:
                    {
                        float currentDamageBonus = _playerAttack != null ? _playerAttack.BulletDamageUP : 0f;
                        _valueText.text = $"+0.5 (현재: {currentDamageBonus:F1})";
                        break;
                    }
                case UpgradeType.AttackSpeed:
                    {
                        float currentCoolDown = _playerAttack != null ? _playerAttack.CoolDownTime : 0.5f;
                        _valueText.text = $"+0.01 (현재: {currentCoolDown:F2}s)";
                        break;
                    }
                case UpgradeType.MoveSpeed:
                    {
                        float currentSpeed = _playerSpeedControl != null ? _playerSpeedControl.PlayerSpeed : 5f;
                        _valueText.text = $"+0.5 (현재: {currentSpeed:F1})";
                        break;
                    }
                case UpgradeType.All:
                    {
                        _valueText.text = "+0.5 / +0.05 / +0.5";
                        break;
                    }
            }
        }
        // 3. ScoreCostText 갱신
        if (_scoreCostText != null)
        {
            _scoreCostText.text = $"{_coinCost} 코인";
        }
    }
}
