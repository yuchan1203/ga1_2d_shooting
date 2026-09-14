using UnityEngine;
// 업그레이드들에 대한 무결성과 생성,조회,수정,삭제 등과 관련된 게임 로직을 관리하는 스크립트 
public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager _instance = null;
    public static UpgradeManager Instance => _instance;
    [SerializeField] private UI_UpgradeButton[] _uiUpgradeButtons;
    private void Awake()
    {
        if (_instance == null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }
    private void Start()
    {
        RefreshUI();
    }
    public void LevelUp(int index)
    {
        _uiUpgradeButtons[index].OnClickUpgrade();

        RefreshUI();
    }
    // UI 갱신
    private void RefreshUI()
    {
        foreach (UI_UpgradeButton uiUpgrade in _uiUpgradeButtons)
        {
            uiUpgrade.UpdateUI();
        }
    }
}