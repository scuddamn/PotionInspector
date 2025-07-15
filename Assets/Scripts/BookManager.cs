using System;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField] List<GameObject> snapPositions;
    [SerializeField] private float moveSpeed = 1.0f;
    private GameObject bookCanvas;
    private bool isHover = false;
    private GameObject guidebook;
    private Vector3 bookPosition;
    private Vector3 targetPosition;
    
    private void Awake()
    {
        bookCanvas = GameObject.FindWithTag("BookUI");
        guidebook = GameObject.FindWithTag("Guidebook");
        bookPosition = new Vector3(guidebook.transform.position.x, guidebook.transform.position.y);
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bookPosition = snapPositions[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    { 
        
        bookPosition = Vector3.Lerp(bookPosition, targetPosition, moveSpeed * Time.deltaTime);
        
    }
    
    private void OnMouseEnter()
    {
        isHover = true;
        targetPosition = snapPositions[1].transform.position;
    }

    private void OnMouseExit()
    {
        isHover = false;
        targetPosition = snapPositions[0].transform.position;
    }

    private void OnMouseDown()
    {
        if (isHover)
        {
            bookPosition = Vector3.Lerp(bookPosition, snapPositions[2].transform.position, moveSpeed * Time.deltaTime);
            bookCanvas.SetActive(true);
        }
    }

    public void BookReturn()
    {
        bookPosition = Vector3.Lerp(bookPosition, snapPositions[0].transform.position, moveSpeed * Time.deltaTime);
    }
}
