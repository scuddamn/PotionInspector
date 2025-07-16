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
        if (isHighlighted == false && !toolMenu.menuOpen)
        {
             transform.DOMove(highlightedPosition.position, moveSpeed);
             isHighlighted = true;
        }
       
    }

    private void OnMouseExit()
    {
        if (isHighlighted && !toolMenu.menuOpen)
        {
            transform.DOMove(startPosition.position, moveSpeed);
            isHighlighted = false;
        }
    }
}
