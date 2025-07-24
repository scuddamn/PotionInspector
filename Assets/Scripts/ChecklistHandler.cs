using UnityEngine;
using UnityEngine.UI;

public class ChecklistHandler : MonoBehaviour
{
    [SerializeField] private Sprite badStamp;
    [SerializeField] private Sprite goodStamp;

    private GameObject stampSeal;
    private Image stampedGraphic;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stampSeal = GameObject.FindGameObjectWithTag("Seal");
        stampedGraphic = stampSeal.GetComponent<Image>();
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
