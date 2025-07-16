using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class BookManager : MonoBehaviour
{
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
    
    public void MoveToOpen()
    {
            transform.DOMove(snapPositions[2].transform.position, moveSpeed);
            isOpen = true;
            Invoke(nameof(OpenMenu), 1f);
            
    }

    void OpenMenu()
    {
        bookCanvas.SetActive(true);
        bodyText.alpha = 0;
        titleText.alpha = 0;
        bookPage.GetComponent<Animator>().SetTrigger("fadeIn");
        FadeInText();
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
        FadeOutText();
        bookPage.GetComponent<Animator>().SetTrigger("fadeOut");
        Invoke(nameof(CloseBook), pageFadeSpeed);
    }
    
}
