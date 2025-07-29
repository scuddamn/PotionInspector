using System;
using UnityEngine;

public class ChecklistSeal : MonoBehaviour
{
    private StampTool stamp;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stamp = FindFirstObjectByType<StampTool>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Seal"))
        {
            stamp.StampIt();
        }
    }
}
