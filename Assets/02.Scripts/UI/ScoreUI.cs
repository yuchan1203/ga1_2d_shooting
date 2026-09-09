using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timeText;

    [SerializeField] private int _scorePerKill = 100;
    [SerializeField] private float _scorePerSecond = 10f;

    private float _currentScore = 0f;
    private float _playTime = 0f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        // 시간 경과 및 플레이 시간 비례 점수 증가
        _playTime += Time.deltaTime;
        _currentScore += _scorePerSecond * Time.deltaTime;

        UpdateUI();
    }

    // 적 처치 시 호출할 함수
    public void AddKillScore()
    {
        _currentScore += _scorePerKill;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_scoreText != null) _scoreText.text = $"점수: {(int)_currentScore}";
        if (_timeText != null) _timeText.text = $"시간: {(int)_playTime}s";
    }
}