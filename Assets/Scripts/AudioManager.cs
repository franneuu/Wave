using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource audioSourceMusic, audioSourceSFX;
    [SerializeField] private AudioClip audioClipMusic;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        PlaySoundLoop(audioClipMusic);
    }

    public void PlaySoundOneShot(AudioClip soundToPlay)
    {
        audioSourceSFX.PlayOneShot(soundToPlay);
    }

    public void PlaySoundLoop(AudioClip soundToPlay)
    {
        audioSourceMusic.loop = true;
        audioSourceMusic.PlayOneShot(soundToPlay);
    }
}

