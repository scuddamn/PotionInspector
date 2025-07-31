using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BellScript : MonoBehaviour
{
    [SerializeField] private RectTransform offscreenSnap;
    [SerializeField] private RectTransform onscreenSnap;
    [SerializeField] private float dropDuration = 0.5f;

    private AudioManager audioManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        transform.position = offscreenSnap.position; //start bell offscreen
    }

    public void DropBell()
    {
        transform.DOMove(onscreenSnap.position, dropDuration);
        StartCoroutine(BellLand());
        audioManager.DropBellSFX();

    }

    IEnumerator BellLand()
    {
        yield return new WaitForSeconds(dropDuration - 0.3f);
        transform.DOShakeRotation(0.3f, 50f, 80);
        
    }
}
