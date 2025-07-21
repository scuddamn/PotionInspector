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
    
    [Header("Movement Speed")]
    [SerializeField] private float moveSpeed = 1f;

    public bool menuOpen;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // gameObject.transform.position = offscreenPosition.position; //ensure menu starts offscreen
    }

    public void OpenMenu()
    {
        GetComponentInChildren<Button>().interactable = true;
        menuButton.transform.DOMove(buttonHide.position, moveSpeed);
        transform.DOMove(openPosition.position, moveSpeed);
        menuOpen = true;
    }

    public void CloseMenu()
    {
        GetComponentInChildren<Button>().interactable = false;
        transform.DOMove(offscreenPosition.position, moveSpeed);
        menuButton.transform.DOMove(buttonReturn.position, moveSpeed);
        menuOpen = false;
    }
}
