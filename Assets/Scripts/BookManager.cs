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
    
    [Header("Book Hover + Movement")]
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
    
    void Start()
    {
        titleText.alpha = 0;
        bodyText.alpha = 0; //set initial text alpha value to 0, so the text can fade in upon opening the menu
    }
    
    public void MoveToOpen() //move the book to the 'activated' position on the desk
    {
            transform.DOMove(snapPositions[2].transform.position, moveSpeed);
            isOpen = true;
            transform.DOScale(2f, 1f);
            Invoke(nameof(OpenMenu), 1f);
    }

    void OpenMenu() //opens the book menu
    {
        bookCanvas.SetActive(true);
        bookPage.GetComponent<Animator>().SetTrigger(FadeIn); //page materializes with animation
        FadeInText();
        bookPage.GetComponentInChildren<Button>().interactable = true; //makes menu close button 'x' interactable
        
    }

    void FadeInText() //page text fades in to full alpha
    {
        bodyText.DOFade(1, textFadeSpeed);
        titleText.DOFade(1, textFadeSpeed);
    }
    
    void FadeOutText() //page text fades from full alpha to 0 
    {
        bodyText.DOFade(0, textFadeSpeed);
        titleText.DOFade(0, textFadeSpeed);
    }
    
    public void MoveOffscreen() //moves book offscreen to initial position
    {
        transform.DOMove(snapPositions[0].transform.position, moveSpeed);
    }

    public void MoveToHover() //move book to be slightly onscreen when hovering over a specific area - connected to BookHover script
    {
        transform.DOMove(snapPositions[1].transform.position, moveSpeed);
    }

    void CloseBook() //book menu closes
    {
        transform.DOScale(1f, 1f);
        bookCanvas.SetActive(false);
        isOpen = false;
    }

    public void LeaveMenu() //menu closing process begins
    {
        bookPage.GetComponentInChildren<Button>().interactable = false; //once the 'x' button is pressed to close the menu, it cannot be pressed again
        FadeOutText();
        bookPage.GetComponent<Animator>().SetTrigger(FadeOut); //animation makes page disappear
        Invoke(nameof(CloseBook), pageFadeSpeed);
    }
    
}
