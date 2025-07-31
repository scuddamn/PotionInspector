using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [Header("All Menus")]
    [SerializeField] private AudioClip[] menuSound;
    
    [Header("Inspector Menu")]
    [SerializeField] AudioClip sniffSound;
    [SerializeField] private AudioClip tasteSound;
    
    private AudioClip randMenuSound;
    private AudioSource sfxPlayer; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfxPlayer = GetComponent<AudioSource>();
    }

    void GetRandomSFX() //choose random sound from array
    {
        int randomIndex = Random.Range(0, menuSound.Length);
        randMenuSound = menuSound[randomIndex];
    }

    public void PlayMenuSFX() //play sfx
    {
        GetRandomSFX();
        sfxPlayer.PlayOneShot(randMenuSound);
    }

    public void PlaySniffSFX()
    {
        sfxPlayer.PlayOneShot(sniffSound);
    }

    public void PlayTasteSFX()
    {
        sfxPlayer.PlayOneShot(tasteSound);
    }
}
