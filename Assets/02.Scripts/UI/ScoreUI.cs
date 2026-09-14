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
    private int bomb = 0;
    private int coin = 0;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Update()
    {
        playTime += Time.deltaTime;
        //_currentScore += _scorePerSecond * Time.deltaTime;
        UpdateUI();
    }
    private void UpdateUI()
    {
        if (_timeText != null) _timeText.text = $"시간: {(int)playTime}s";
        if (_bombText != null) _bombText.text = $"폭탄: {bomb}개";
        if (_coinText != null) _coinText.text = $"코인: {coin}개";
    }
}