using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject inspectorMenu;
    [SerializeField] private GameObject toolMenu;
    [SerializeField] private GameObject checklistMenu;
    
    //menu management 

    public void OpenInspector() //to be called when clicking the 'inspect' button
    {
        inspectorMenu.SetActive(true);
    }

    public void CloseInspector() //to be called when clicking 'x' on the inspector menu
    {
        inspectorMenu.SetActive(false);
    }

    public void OpenTools() //called when clicking 'tools' button
    {
        toolMenu.SetActive(true);
    }

    public void CloseTools() //for minimizing tool menu
    {
        toolMenu.SetActive(false);
    }

    public void OpenChecklist() //open menu after clicking checklist icon
    {
        checklistMenu.SetActive(true);
    }

    public void CloseChecklist() //close menu after clicking 'x'
    {
        checklistMenu.SetActive(false);
    }
}
