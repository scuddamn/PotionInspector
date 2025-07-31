using UnityEngine;

public class ObjAudio : MonoBehaviour
{
    [Header("Desk Bell")]
    [SerializeField] private AudioClip bellDropSFX;
    [SerializeField] private AudioClip bellRing;

    [Header("Potion")] [SerializeField] private AudioClip potionClink;

    [Header("Tools")]
    [SerializeField] private AudioClip dropperSFX;
    [SerializeField] private AudioClip stampSound;
    [SerializeField] private AudioClip lightCandleSFX;
    [SerializeField] private AudioClip[] toolPickUpSFX;
    
    private int randomIndex;
    private AudioSource sfxAudio;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfxAudio = GetComponent<AudioSource>();
    }

    void GetRandomIndex()
    {
        randomIndex = Random.Range(0, toolPickUpSFX.Length);
    }

    public void PlayBellDropSFX()
    {
        sfxAudio.PlayOneShot(bellDropSFX);
    }

    public void PlayBellRingSFX()
    {
        sfxAudio.PlayOneShot(bellRing);
    }

    public void PlayPotionClink()
    {
        sfxAudio.PlayOneShot(potionClink);
    }

    public void PlayToolPickupSFX()
    {
        GetRandomIndex();
        sfxAudio.PlayOneShot(toolPickUpSFX[randomIndex]);
    }

    public void PlayDropperSound()
    {
        sfxAudio.PlayOneShot(dropperSFX);
    }

    public void PlayCandleSound()
    {
        sfxAudio.PlayOneShot(lightCandleSFX);
    }

    public void PlayStampSound()
    {
        sfxAudio.PlayOneShot(stampSound);
    }
}
