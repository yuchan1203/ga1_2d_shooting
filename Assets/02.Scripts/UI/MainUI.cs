using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private Button _gameStartButton;
    [SerializeField] private string _gameSceneName = "GameScene";

    private void Start()
    {
        if (_gameStartButton != null)
        {
            _gameStartButton.onClick.AddListener(OnGameStartButtonClicked);
        }
    }

    public void OnGameStartButtonClicked()
    {
        SceneManager.LoadScene(_gameSceneName);
    }
}