using UnityEngine;


public class BookHover : MonoBehaviour
{
    private BookManager bookManager;
    private Collider2D hoverArea;
    private bool hoverable = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hoverArea = GetComponent<Collider2D>();
        bookManager = FindFirstObjectByType<BookManager>(); //get reference to the script on the book item
        ZoneClose(); //before the "open stall" button is pressed, the book will not be interactable
    }

    public void ZoneClose()
    {
        hoverArea.enabled = false;
        hoverable = false;
    }

    public void ZoneOpen()
    {
        hoverArea.enabled = true;
        hoverable = true;
    }

    private void OnMouseEnter()
    { //while hovering over area
        
        if (hoverable && !bookManager.IsOpen())
        {
            bookManager.MoveToHover();
            print("hovering");
        }
    }

    private void OnMouseExit()
    { //when stopped hovering over area
        
        if (hoverable && !bookManager.IsOpen())
        {
            bookManager.MoveOffscreen();
            print("leaving hover");
        }
    }

    private void OnMouseDown()
    { //when the book/hover zone is clicked on
        if (hoverable && !bookManager.IsOpen())
        {
            bookManager.MoveToOpen();
        }
        
    }
}
