using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BookManager : MonoBehaviour
{
    [SerializeField] List<GameObject> snapPositions;
    [SerializeField] private float moveSpeed = 1.0f;
    private GameObject bookCanvas;
    private bool isOpen;

    public bool IsOpen()
    {
        return isOpen;
    }

    private void Awake()
    {
        bookCanvas = GameObject.FindWithTag("BookUI");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToOpen()
    {
            transform.DOMove(snapPositions[2].transform.position, moveSpeed);
            bookCanvas.SetActive(true);
            isOpen = true;
    }

    public void MoveOffscreen()
    {
        transform.DOMove(snapPositions[0].transform.position, moveSpeed);
    }

    public void MoveToHover()
    {
        transform.DOMove(snapPositions[1].transform.position, moveSpeed);
    }

    public void CloseBook()
    {
        bookCanvas.SetActive(false);
        isOpen = false;
    }
    
    
}
