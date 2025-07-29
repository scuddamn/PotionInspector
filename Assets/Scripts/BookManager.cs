using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    private static readonly int Open = Animator.StringToHash("open");
    private static readonly int FadeIn = Animator.StringToHash("fadeIn");
    private static readonly int FadeOut = Animator.StringToHash("fadeOut");
    private static readonly int TurnBack = Animator.StringToHash("turnBack");
    private static readonly int TurnNext = Animator.StringToHash("turnNext");
    private static readonly int Close = Animator.StringToHash("close");

    [Header("Book Hover + Movement")]
    [SerializeField] List<GameObject> snapPositions;
    [SerializeField] private float moveSpeed = 1.0f;
    
    [Header("Book Menu")]
    [SerializeField] private GameObject bookCanvas;
    [SerializeField] private GameObject bookPage;
    [SerializeField] private float textFadeSpeed = 1f;
    [SerializeField] private TMP_Text[] pageText;
    [SerializeField] private float pageFadeSpeed = 2f;

    private Animator animator;
    
    private bool isOpen;

    public bool IsOpen()
    {
        return isOpen;
    }
    
    void Start()
    {
        foreach (var text in pageText)
        {
            text.alpha = 0;
        } //set initial text alpha value to 0, so the text can fade in upon opening the menu
        
        animator = GetComponentInChildren<Animator>();
    }
    
    public void MoveToOpen() //move the book to the 'activated' position on the desk
    {
            transform.DOMove(snapPositions[2].transform.position, moveSpeed);
            animator.SetTrigger(Open);
            transform.DOScale(2.1f, moveSpeed);
            isOpen = true;
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
        foreach (var text in pageText)
        {
            text.DOFade(1, textFadeSpeed);
        }
        
        
    }
    
    void FadeOutText() //page text fades from full alpha to 0 
    {
        foreach (var text in pageText)
        {
            text.DOFade(0, textFadeSpeed);
        }
    }
    
    public void MoveOffscreen() //moves book offscreen to initial position
    {
        transform.DOMove(snapPositions[0].transform.position, moveSpeed);
    }

    public void MoveToHover() //move book to be slightly onscreen when hovering over a specific area - connected to BookHover script
    {
        transform.DOMove(snapPositions[1].transform.position, moveSpeed);
    }

    public void TurnPageNext()
    {
        animator.SetTrigger(TurnNext);
    }

    public void TurnPageBack()
    {
        animator.SetTrigger(TurnBack);
    }

    void CloseBook() //book menu closes
    {
        animator.SetTrigger(Close);
        transform.DOScale(1f, 1f);
        bookCanvas.SetActive(false);
        isOpen = false;
        MoveOffscreen();
    }

    public void LeaveMenu() //menu closing process begins
    {
        bookPage.GetComponentInChildren<Button>().interactable = false; //once the 'x' button is pressed to close the menu, it cannot be pressed again
        FadeOutText();
        bookPage.GetComponent<Animator>().SetTrigger(FadeOut); //animation makes page disappear
        Invoke(nameof(CloseBook), pageFadeSpeed);
    }
    
}
