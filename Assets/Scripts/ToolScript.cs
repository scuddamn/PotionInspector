using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ToolScript : MonoBehaviour
{
    [SerializeField] private RectTransform snapPosition;
    
    private bool onDesk;

    public bool OnDesk()
    {
        return onDesk;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ChangeState(bool state)
    {
        onDesk = state switch
        {
            true => true,
            false => false
        };
    }

    public void OnMouseUpAsButton()
    {
        if (!onDesk)
        {
            transform.DOMove(snapPosition.position, 0.2f);
        }
    }
}
