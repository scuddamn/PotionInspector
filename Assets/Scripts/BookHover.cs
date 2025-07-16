using System;
using UnityEngine;

public class BookHover : MonoBehaviour
{
    private BookManager bookManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bookManager = FindFirstObjectByType<BookManager>(); //get reference to the script on the book item
    }

    // Update is called once per frame
    void Update()
    {
        
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
