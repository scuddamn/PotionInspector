
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ToolMenu : MonoBehaviour
{
    [Header("Menu Snap Locations")]
    [SerializeField] private Transform offscreenPosition;
    [SerializeField] private Transform openPosition;
    
    [Header("Button")]
    [SerializeField] private GameObject menuButton;
    [SerializeField] private Transform buttonHide;
    [SerializeField] private Transform buttonReturn;
   
    [Header("Buttons to Hide")]
    [Tooltip("remove interactability on buttons beneath menu while menu is open")] [SerializeField] private List<Button> hideableButtons;
    
    [Header("Movement Speed")]
    [SerializeField] private float moveSpeed = 1f;
    
    private bool menuOpen = false;
    private AudioManager audioManager;

    public bool MenuOpen()
    {
        return menuOpen;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    public void OpenMenu()
    {
        GetComponentInChildren<Button>().interactable = true; //make minimize button interactable
        menuButton.transform.DOMove(buttonHide.position, moveSpeed); //move initial menu button offscreen
        transform.DOMove(openPosition.position, moveSpeed); //menu slides into frame
        audioManager.MenuSFX();
        menuOpen = true;
        
        foreach (Button button in hideableButtons) //make the buttons that get hidden by the open menu NOT interactable to prevent misclicks
        {
            button.interactable = false;
        }
    }

    public void CloseMenu()
    {
        
        GetComponentInChildren<Button>().interactable = false; //once minimize button has been clicked, it cannot be clicked again
        transform.DOMove(offscreenPosition.position, moveSpeed); //menu slides offscreen
        menuButton.transform.DOMove(buttonReturn.position, moveSpeed); //menu button returns to screen
        audioManager.MenuSFX();
        menuOpen = false;

        foreach (Button button in hideableButtons) //re-enable interactability on buttons that were hidden by the menu
        { 
            button.interactable = true;
        }
    }
    
}
