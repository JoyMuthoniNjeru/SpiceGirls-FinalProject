using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip dotCollectSound;
    public AudioClip speedBoostSound;
    public AudioClip shootPickupSound;
    public AudioClip projectileFireSound;
    public AudioClip enemyCatchSound;
    public AudioClip levelCompleteSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayDotCollect()
    {
        PlaySFX(dotCollectSound);
    }

    public void PlaySpeedBoost()
    {
        PlaySFX(speedBoostSound);
    }

    public void PlayShootPickup()
    {
        PlaySFX(shootPickupSound);
    }

    public void PlayProjectileFire()
    {
        PlaySFX(projectileFireSound);
    }

    public void PlayEnemyCatch()
    {
        PlaySFX(enemyCatchSound);
    }

    public void PlayLevelComplete()
    {
        PlaySFX(levelCompleteSound);
    }

    void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }
}