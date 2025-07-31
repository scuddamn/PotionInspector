using UnityEngine;

public class BookAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] pageTurnSFX;
    [SerializeField] private AudioClip[] openBookSFX;
    [SerializeField] private AudioClip[] closeBookSFX;

    private int randomIndex;
    private AudioSource sfxAudio;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfxAudio = GetComponent<AudioSource>();
    }

    void GetRandomIndex(AudioClip[] soundSource)
    {
        randomIndex = Random.Range(0, soundSource.Length);
    }

    public void PlayPageTurnSFX()
    {
        GetRandomIndex(pageTurnSFX);
        sfxAudio.PlayOneShot(pageTurnSFX[randomIndex]);
    }
    
    public void PlayOpenBookSFX()
    {
        GetRandomIndex(openBookSFX);
        sfxAudio.PlayOneShot(openBookSFX[randomIndex]);
    }
    
    public void PlayCloseBookSFX()
    {
        GetRandomIndex(closeBookSFX);
        sfxAudio.PlayOneShot(closeBookSFX[randomIndex]);
    }

    
}
