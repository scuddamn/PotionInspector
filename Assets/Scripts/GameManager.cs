using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //menus for management
    [SerializeField] private GameObject inspectorMenu;
    [SerializeField] private GameObject toolMenu;
    [SerializeField] private GameObject checklistMenu; 
    
    //menu management for starting the game
    [SerializeField] private GameObject openButton;
    [SerializeField] private GameObject gameplayObjects;
    
    
    private void Awake()
    { //even if something is disabled in the inspector, the game will initialize with correct active and inactive objects/menus
        openButton.SetActive(true);
        gameplayObjects.SetActive(false);
        inspectorMenu.SetActive(false);
        checklistMenu.SetActive(false);
    }

    public void OpenInspector() //to be called when clicking the 'inspect' button
    {
        inspectorMenu.SetActive(true);
    }

    public void CloseInspector() //to be called when clicking 'x' on the inspector menu
    {
        inspectorMenu.SetActive(false);
    }

    public void OpenChecklist() //open menu after clicking checklist icon
    {
        checklistMenu.SetActive(true);
    }

    public void CloseChecklist() //close checklist menu after clicking 'x'
    {
        checklistMenu.SetActive(false);
        Cursor.SetCursor(null, Vector2.down, CursorMode.Auto);
    }

    
}
