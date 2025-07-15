using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BookManager : MonoBehaviour
{
    [SerializeField] List<GameObject> snapPositions;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private GameObject bookCanvas;
    private bool isOpen;

    public bool IsOpen()
    {
        return isOpen;
    }
    
    public void MoveToOpen()
    {
            transform.DOMove(snapPositions[2].transform.position, moveSpeed);
            isOpen = true;
            Invoke(nameof(OpenMenu), 1f);
            
    }

    void OpenMenu()
    {
        bookCanvas.SetActive(true);
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
