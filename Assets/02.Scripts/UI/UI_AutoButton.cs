using UnityEngine;
using UnityEngine.UI;
// 버튼을 클릭하면 플레이어의 자동 이동과 공격을 토글하는 스크립트 
public class UI_AutoButton : MonoBehaviour
{
    private bool autoMode = false;
    private Player player;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    private Image myImage;
    private void Start()
    {
        myImage = GetComponent<Image>();
        player = GameObject.FindAnyObjectByType<Player>();
    }
    public void AutoToggle()
    {
        autoMode = !autoMode;
        player.GetComponent<PlayerAttack>().SetAuto(autoMode);
        player.GetComponent<PlayerMove>().enabled = !autoMode;
        player.GetComponent<PlayerAutoMove>().enabled = autoMode;
        myImage.sprite = autoMode ? _onSprite : _offSprite;
        AudioManager.Instance.PlayUIButtonClicked();
    }

}