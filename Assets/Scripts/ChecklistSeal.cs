using System;
using UnityEngine;
using UnityEngine.UI;

public class ChecklistSeal : MonoBehaviour
{
    private StampTool stamp;
    private Toggle seal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stamp = FindFirstObjectByType<StampTool>();
        seal = GetComponent<Toggle>();
    }

    private void Update()
    {
        if (stamp.UsingStamp())
        {
            seal.interactable = true;
            
        } else if (!stamp.UsingStamp())
        {
            seal.interactable = false;
        }
    }
}
