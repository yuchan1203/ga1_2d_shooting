using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScoreTextUI;
    [SerializeField] private TextMeshProUGUI _currentScoreTextUI;
    private int _bestScore = 0;
    private int _currentScore = 0;
    private void Update()
    {
        //_playTime += Time.deltaTime;
        //_currentScore += _scorePerSecond * Time.deltaTime;
        UpdateUI();
    }
    private void UpdateUI()
    {
        if (_bestScoreTextUI != null) _bestScoreTextUI.text = $"최고 점수: {_bestScore}점";
        if (_currentScoreTextUI != null) _currentScoreTextUI.text = $"점수: {_currentScore}점";
    }
}