using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip[] musicClips; // M�zik kliplerini buraya ekleyin
    private int currentClipIndex = 0; // �u anda �alan m�zi�in indeksi
    public bool isMuted = false; // Ses durumu

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            PlayMusic(); // Oyunu ba�latt���m�zda m�zik �almaya ba�las�n
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // M�zik bitti�inde bir sonraki par�aya ge�
        if (!audioSource.isPlaying && !isMuted)
        {
            PlayNextMusic();
        }
    }

    void PlayMusic()
    {
        if (musicClips.Length > 0 && !isMuted)
        {
            audioSource.clip = musicClips[currentClipIndex];
            audioSource.Play();
        }
    }

    void PlayNextMusic()
    {
        currentClipIndex = (currentClipIndex + 1) % musicClips.Length; // S�radaki par�aya ge�, e�er son par�aysa ba�a d�n
        PlayMusic();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}
