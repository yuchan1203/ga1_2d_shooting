using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioSource _sfxSource;
    [Header("BGM")]
    public AudioClip DefaultBgmSound;
    [Header("SFX")]
    public AudioClip EnemyDeadSound;
    public AudioClip PlayerDeadSound;
    public AudioClip GetItemSound;
    public AudioClip PlayerShootSound;
    public AudioClip EnemyHitSound;
    public AudioClip PlayerHitSound;
    public AudioClip BossSummonSound;
    public AudioClip GameStartSound;
    public AudioClip UIButtonClicked;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateAndPlayBGM(scene.name);
    }
    public void UpdateAndPlayBGM()
    {
        UpdateAndPlayBGM(SceneManager.GetActiveScene().name);
    }
    private void UpdateAndPlayBGM(string sceneName)
    {
        if (_bgmSource == null) return;
        AudioClip targetClip = DefaultBgmSound;
        _bgmSource.pitch = 1f;
        if (_bgmSource.clip == targetClip) return;
        _bgmSource.clip = targetClip;
        _bgmSource.loop = true;
        if (targetClip != null) _bgmSource.Play();
        else _bgmSource.Stop();
    }
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && _sfxSource != null) _sfxSource.PlayOneShot(clip);
    }
    public void PlayEnemyDeadSound() => PlaySFX(EnemyDeadSound);
    public void PlayPlayerDeadSound() => PlaySFX(PlayerDeadSound);
    public void PlayGetItemSound() => PlaySFX(GetItemSound);
    public void PlayPlayerShootSound() => PlaySFX(PlayerShootSound);
    public void PlayEnemyHitSound() => PlaySFX(EnemyHitSound);
    public void PlayBossSummonSound() => PlaySFX(BossSummonSound);
    public void PlayGameStartSound() => PlaySFX(GameStartSound);
    public void PlayUIButtonClicked() => PlaySFX(UIButtonClicked);
    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }
}
