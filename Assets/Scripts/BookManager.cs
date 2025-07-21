using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    private static readonly int FadeOut = Animator.StringToHash("fadeOut");
    private static readonly int FadeIn = Animator.StringToHash("fadeIn");
    
    [SerializeField] List<GameObject> snapPositions;
    [SerializeField] private float moveSpeed = 1.0f;
    
    [Header("Book Menu")]
    [SerializeField] private GameObject bookCanvas;
    [SerializeField] private GameObject bookPage;
    [SerializeField] private float textFadeSpeed = 1f;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text bodyText;
    [SerializeField] private float pageFadeSpeed = 2f;
    
    private bool isOpen;

    public bool IsOpen()
    {
        return isOpen;
    }
    

    // public void ChangePressability()
    // {
    //     switch (justPressed)
    //     {
    //         case true:
    //             justPressed = false;
    //             break;
    //         case false:
    //             justPressed = true;
    //             break;
    //     }
    // }
    
    public void MoveToOpen()
    {
            transform.DOMove(snapPositions[2].transform.position, moveSpeed);
            isOpen = true;
            Invoke(nameof(OpenMenu), 1f);
    }

    void OpenMenu()
    {
        bodyText.alpha = 0;
        titleText.alpha = 0;
        bookCanvas.SetActive(true);
        bookPage.GetComponent<Animator>().SetTrigger(FadeIn);
        FadeInText();
        bookPage.GetComponentInChildren<Button>().interactable = true;
        
    }

    void FadeInText()
    {
        bodyText.DOFade(255, textFadeSpeed);
        titleText.DOFade(255, textFadeSpeed);
    }
    
    void FadeOutText()
    {
        bodyText.DOFade(0, textFadeSpeed);
        titleText.DOFade(0, textFadeSpeed);
    }
    
    public void MoveOffscreen()
    {
        transform.DOMove(snapPositions[0].transform.position, moveSpeed);
    }

    public void MoveToHover()
    {
        transform.DOMove(snapPositions[1].transform.position, moveSpeed);
    }

    void CloseBook()
    {
        bookCanvas.SetActive(false);
        isOpen = false;
    }

    public void LeaveMenu()
    {
        bookPage.GetComponentInChildren<Button>().interactable = false;
        FadeOutText();
        bookPage.GetComponent<Animator>().SetTrigger(FadeOut);
        Invoke(nameof(CloseBook), pageFadeSpeed);
    }
    
}
