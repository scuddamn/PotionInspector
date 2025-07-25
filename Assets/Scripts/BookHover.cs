using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class BookHover : MonoBehaviour
{
    [SerializeField] private GameObject toolHolder;
    private BookManager bookManager;
    private Collider2D hoverArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hoverArea = GetComponent<Collider2D>();
        bookManager = FindFirstObjectByType<BookManager>(); //get reference to the script on the book item
    }

    // Update is called once per frame
    void Update()
    {
        if (toolHolder.transform.childCount > 0)
        {
            hoverArea.enabled = false;
        } else if (toolHolder.transform.childCount <= 0)
        {
            hoverArea.enabled = true;
        }
    }

    private void OnMouseEnter()
    { //while hovering over area
        
        if (!bookManager.IsOpen())
        {
            bookManager.MoveToHover();
            print("hovering");
        }
    }

    private void OnMouseExit()
    { //when stopped hovering over area
        
        if (!bookManager.IsOpen())
        {
            bookManager.MoveOffscreen();
            print("leaving hover");
        }
    }

    private void OnMouseDown()
    {
        if (!bookManager.IsOpen())
        {
            bookManager.MoveToOpen();
        }
        
    }
}
