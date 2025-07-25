using System;
using UnityEngine;
using UnityEngine.UI;

public class DropperTool : MonoBehaviour
{
    [SerializeField] private float dropperFollowSpeed = 0.5f;
    [SerializeField] private GameObject droplet;
    private ToolScript thisTool;
    private PotionManager potionManager;
    private bool usingDropper = false;
    private Vector3 mousePosition;
    private bool gotDrop = false;
    private Color dropletColor;

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
        if (Input.GetMouseButtonDown(1) && thisTool.OnDesk())
        {
            usingDropper = true;
            GetComponent<Collider2D>().enabled = false;
            GetDropletColor();
            GetComponent<Image>().raycastTarget = false;
        }
    }

    private void GetDropletColor()
    {
        potionManager.CurrentPotion().GetPotionColor();
    }
    

    private void Update()
    {
        if (usingDropper)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, dropperFollowSpeed);
        }
        else if (usingDropper && Input.GetMouseButtonDown(1))
        {
            usingDropper = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Image>().raycastTarget = false;
            if (gotDrop)
            {
                droplet.SetActive(false);
            }
        }
        
        
        
    }

    public void MakeDroplet()
    {
        droplet.SetActive(true);
        droplet.GetComponent<Image>().color = dropletColor;
        gotDrop = true;
    }
    
    
}
