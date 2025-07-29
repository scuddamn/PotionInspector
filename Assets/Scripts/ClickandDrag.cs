using System;
using UnityEngine;

public class ClickandDrag : MonoBehaviour
{
    private Vector3 mousePosOffset; //to drag object from whatever point it is clicked
    private DropperTool dropper;

    private void Start()
    {
        dropper = FindFirstObjectByType<DropperTool>();
    }

    Vector3 GetMouseWorldPos()
    {
       return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        if (dropper.UsingDropper()) return;
        
        mousePosOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        if (dropper.UsingDropper()) return;
        transform.position = GetMouseWorldPos() + mousePosOffset;
    }

}
