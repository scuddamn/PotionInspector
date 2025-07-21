using System;
using DG.Tweening;
using UnityEngine;

public class ButtonHighlight : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform highlightedPosition;
    [SerializeField] private float moveSpeed = 1f;
    private ToolMenu toolMenu;
    private bool isHighlighted;

    private void Start()
    {
        toolMenu = FindFirstObjectByType<ToolMenu>();
    }

    private void OnMouseEnter()
    {
        if (isHighlighted == false && !toolMenu.MenuOpen()) //if the menu is closed and the button is not already highlighted
        {
             transform.DOMove(highlightedPosition.position, moveSpeed); //button moves up when mouse is hovering over it
             isHighlighted = true;
        }
       
    }

    private void OnMouseExit()
    {
        if (isHighlighted && !toolMenu.MenuOpen()) //if the button is in the highlighted position and the menu itself is closed
        {
            transform.DOMove(startPosition.position, moveSpeed); //button returns to non-highlighted position
            isHighlighted = false;
        }
    }
}
