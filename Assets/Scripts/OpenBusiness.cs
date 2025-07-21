using System;
using System.Net.Mime;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class OpenBusiness : MonoBehaviour
{
    [Tooltip("time before menu fully closes")][SerializeField] private float closeDelay = 2f;
    [SerializeField] private GameObject loadOnPlay;
    
    private TMP_Text signText;
    private static readonly int Fade = Animator.StringToHash("fade");
    

    private void Start()
    {
        GetComponent<Button>().interactable = true;
        signText = GetComponentInChildren<TMP_Text>();
    }

    void StartGame()
    {
        gameObject.SetActive(false); //turn off 'open stall' button
        loadOnPlay.SetActive(true); //enable main gameplay objects
    }

    public void OpenStall()
    {
        GetComponent<Button>().interactable = false;
        GetComponent<Animator>().SetTrigger(Fade);
        signText.DOFade(0f, 0.5f);
        
        
        Invoke(nameof(StartGame), closeDelay);
    }
}
