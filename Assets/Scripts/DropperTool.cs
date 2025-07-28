using System;
using UnityEngine;
using UnityEngine.UI;

public class DropperTool : MonoBehaviour
{
    [SerializeField] private float dropperFollowSpeed = 0.5f;
    private ToolScript thisTool;
    private PotionManager potionManager;
    private bool usingDropper = false;
    private Vector3 mousePosition;
    private bool gotDrop = false;

    public bool GotDrop()
    {
        return gotDrop;
    }

    public bool UsingDropper()
    {
        return usingDropper;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisTool = GetComponent<ToolScript>();
        potionManager = FindFirstObjectByType<PotionManager>();
    }

    private void OnMouseOver()
    {
        if (!usingDropper && Input.GetMouseButtonDown(1) && thisTool.OnDesk())
        {
            usingDropper = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Image>().raycastTarget = false;
        }
    }
    

    private void Update()
    {
        if (usingDropper)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, dropperFollowSpeed);
        }

        if (usingDropper && Input.GetMouseButtonDown(1))
        {
            
        }
    }

    public void MakeDroplet()
    {
        potionManager.DisplayDroplet();
        gotDrop = true;
    }

    public void LoseDroplet()
    {
        GetComponentInChildren<Image>().enabled = false;
        gotDrop = false;
    }

   
    
    
}
