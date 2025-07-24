using UnityEngine;
using UnityEngine.UI;

public class ChecklistHandler : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ResetChecklist()
    {
        var toggles = GetComponentsInChildren<Toggle>();
        foreach (var toggle in toggles)
        {
            toggle.isOn = false;
        }
    }
}
