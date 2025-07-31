using UnityEngine;

public class ChecklistAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] writeSFX;
    [SerializeField] private AudioClip[] toggleSFX;
    [SerializeField] private AudioClip[] paperSlideSFX;

    private int randomIndex;

    private AudioSource sfxAudio;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfxAudio = GetComponent<AudioSource>();
    }

    void GetRandomSound(AudioClip[] soundSource) //randomize which sfx option is selected
    {
        randomIndex = Random.Range(0, soundSource.Length);
    }

    public void PlayWritingSFX() //play sound effect, called from corresponding gameobject
    {
        GetRandomSound(writeSFX);
        sfxAudio.PlayOneShot(writeSFX[randomIndex]);
    }

    public void PlayToggleSFX()
    {
        GetRandomSound(toggleSFX);
        sfxAudio.PlayOneShot(toggleSFX[randomIndex]);
    }

    public void PlayPaperSlideSFX()
    {
        GetRandomSound(paperSlideSFX);
        sfxAudio.PlayOneShot(paperSlideSFX[randomIndex]);
    }
}
