using System;
using UnityEngine;
using UnityEngine.UI;

public class CandleTool : MonoBehaviour
{
    private GameObject flamePrefab;
    private Color flameColor;

    private PotionManager potionManager;
    private DropperTool dropper;
    private ToolScript thisTool;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        potionManager = FindFirstObjectByType<PotionManager>();
        dropper = FindFirstObjectByType<DropperTool>();
        thisTool = GetComponentInParent<ToolScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetFlameInfo()
    {
        flamePrefab = potionManager.CurrentPotion().GetFlamePrefab();
        flameColor = potionManager.CurrentPotion().GetFlameColor();
    }

    private void OnMouseOver()
    {
        if (dropper.GotDrop() && Input.GetMouseButtonDown(0))
        {
            Instantiate(flamePrefab, transform);
            GetComponentInChildren<Image>().color = flameColor;
            dropper.LoseDroplet();
        }
    }
}
