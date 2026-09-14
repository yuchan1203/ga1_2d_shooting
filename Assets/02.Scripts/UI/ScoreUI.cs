using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    public static ScoreUI Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _bombText;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private float _scorePerSecond = 10f;
    private float playTime = 0f;
    private Player _player;
    private PlayerAttack _playerAttack;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        _player = FindFirstObjectByType<Player>();
        if (_player != null)
        {
            _playerAttack = _player.GetComponent<PlayerAttack>();
        }
    }

    private void Update()
    {
        playTime += Time.deltaTime;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_timeText != null)
        {
            _timeText.text = $"시간: {(int)playTime}s";
        }

        if (_bombText != null)
        {
            if (_playerAttack == null && _player != null)
            {
                _playerAttack = _player.GetComponent<PlayerAttack>();
            }
            int bombCount = _playerAttack != null ? _playerAttack.Bomb : 0;
            _bombText.text = $"폭탄: {bombCount}개";
        }

        if (_coinText != null)
        {
            if (_player == null)
            {
                _player = FindFirstObjectByType<Player>();
            }
            int coinCount = _player != null ? _player.Coin : 0;
            _coinText.text = $"코인: {coinCount}개";
        }
    }
}