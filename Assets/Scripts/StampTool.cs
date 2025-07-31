using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StampTool : MonoBehaviour
{
    //assigned to the stamp object that contains the animator (sprite GO)
    
    private static readonly int Stamp = Animator.StringToHash("stamp");
    [SerializeField] private Toggle sealToggle;
    
    private Animator animator;
    private AudioManager audioManager;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        audioManager = FindFirstObjectByType<AudioManager>();

    }

    public void StampIt()
    {
        animator.SetTrigger(Stamp);
    }

    public void Stamped()
    {
        sealToggle.isOn = true;
    }

    public void StampSound()
    {
        audioManager.StampSFX();
    }
}
