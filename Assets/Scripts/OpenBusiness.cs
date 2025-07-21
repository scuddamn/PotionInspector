using System;
using System.Net.Mime;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class OpenBusiness : MonoBehaviour
{
    [SerializeField] private float closeDelay = 2f;
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
        gameObject.SetActive(false);
        loadOnPlay.SetActive(true);
    }

    public void OpenStall()
    {
        GetComponent<Button>().interactable = false;
        signText.DOFade(0f, 0.5f);
        GetComponent<Animator>().SetTrigger(Fade);
        
        Invoke(nameof(StartGame), closeDelay);
    }
}
