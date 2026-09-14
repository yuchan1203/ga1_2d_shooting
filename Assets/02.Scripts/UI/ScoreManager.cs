using UnityEngine;
using TMPro;
// 점수와 최고점수 관리 매니저 
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI _bestScoreTextUI;
    [SerializeField] private TextMeshProUGUI _currentScoreTextUI;
    [SerializeField] private int _scorePerKill = 100;
    private int _bestScore = 0;
    private int _currentScore = 0;
    private void Awake()
    {
        Instance = this;
    }
    public void AddScore(int score)
    {
        _currentScore += score;
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
        }
    }
    public void AddKillScore()
    {
        _currentScore += _scorePerKill;
        UpdateUI();
    }
    private void Update()
    {
        UpdateUI();
    }
    private void UpdateUI()
    {
        if (_bestScoreTextUI != null) _bestScoreTextUI.text = $"최고 점수: {_bestScore}점";
        if (_currentScoreTextUI != null) _currentScoreTextUI.text = $"점수: {_currentScore}점";
    }
}