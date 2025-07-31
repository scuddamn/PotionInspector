using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    private static readonly int Open = Animator.StringToHash("open");
    private static readonly int TurnBack = Animator.StringToHash("turnBack");
    private static readonly int TurnNext = Animator.StringToHash("turnNext");
    private static readonly int Close = Animator.StringToHash("close");

    [Header("Book Hover + Movement")]
    [SerializeField] List<GameObject> snapPositions;
    [SerializeField] private float moveSpeed = 1.0f;
    
    [Header("Book Menu")]
    [SerializeField] private GameObject bookDisplay;
    [SerializeField] private float pageFadeSpeed = 1f;

    private Animator animator;
    private BookHover hoverZone;
    private AudioManager audioManager;
    private GuidebookManager pageGuide;
    
    private bool isOpen;

    public bool IsOpen()
    {
        return isOpen;
    }
    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        hoverZone = FindFirstObjectByType<BookHover>();
        audioManager = FindFirstObjectByType<AudioManager>();
        pageGuide = bookDisplay.GetComponent<GuidebookManager>();
    }
    
    public void MoveToOpen() //move the book to the 'activated' position on the desk
    {
            transform.DOMove(snapPositions[2].transform.position, moveSpeed);
            animator.SetTrigger(Open);
            audioManager.OpenBookSFX();
            transform.DOScale(2.1f, moveSpeed);
            isOpen = true;
            Invoke(nameof(OpenMenu), 1f);
    }

    void OpenMenu() //opens the book menu
    {
        bookDisplay.SetActive(true);
        pageGuide.OnBookOpen();
        bookDisplay.GetComponentInChildren<Button>().interactable = true; //makes menu close button 'x' interactable (and page turn buttons?)
        hoverZone.enabled = false; //the hover area has no effect when the menu is open
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
        audioManager.PageTurnSFX();
    }

    public void TurnPageBack()
    {
        animator.SetTrigger(TurnBack);
        audioManager.PageTurnSFX();
    }

    void CloseBook() //book menu closes
    {
        animator.SetTrigger(Close);
        audioManager.CloseBookSFX();
        transform.DOScale(1f, 1f);
        bookDisplay.SetActive(false);
        isOpen = false;
        hoverZone.enabled = true; //the hover area will function again once the menu is closed
        MoveOffscreen();
    }

    public void LeaveMenu() //menu closing process begins
    {
        bookDisplay.GetComponentInChildren<Button>().interactable = false; //once the 'x' button is pressed to close the menu, it cannot be pressed again
        pageGuide.OnBookClose();
        Invoke(nameof(CloseBook), pageFadeSpeed);
    }
    
}
