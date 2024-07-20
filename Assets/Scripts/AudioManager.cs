using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip[] musicClips; // Müzik kliplerini buraya ekleyin
    private int currentClipIndex = 0; // Þu anda çalan müziðin indeksi
    public bool isMuted = false; // Ses durumu

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            PlayMusic(); // Oyunu baþlattýðýmýzda müzik çalmaya baþlasýn
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Müzik bittiðinde bir sonraki parçaya geç
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
        currentClipIndex = (currentClipIndex + 1) % musicClips.Length; // Sýradaki parçaya geç, eðer son parçaysa baþa dön
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
