using System;
using UnityEngine;
using UnityEngine.UI;

public class ChecklistSeal : MonoBehaviour
{
    [SerializeField] private GameObject stamp;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("seal trigger entered");
        if (other.CompareTag("Seal"))
        {
            stamp.GetComponent<StampTool>().StampIt();
        }
    }
}
