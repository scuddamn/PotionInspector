using System;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject openSign;
    [Tooltip("how quickly menus move into frame")][SerializeField] private float moveSpeed = 1f;
    
    [Header("Inspection Menu")]
    [SerializeField] private GameObject inspectorMenu;
    [SerializeField] private Transform inspectorSnapIn;
    [SerializeField] private Transform inspectorSnapOut;
    private bool inspectorOpen = false;
    
    [Header("Checklist Menu")]
    [SerializeField] private GameObject checklistMenu;
    [SerializeField] private Transform checklistSnapIn;
    [SerializeField] private Transform checklistSnapOut;
    private bool checklistOpen = false;
    
    
    private void Awake()  //start game with menus offscreen
    { 
        inspectorMenu.transform.position = inspectorSnapOut.position;
        checklistMenu.transform.position = checklistSnapOut.position;
    }

    private void Start()
    {
        openSign.SetActive(true);
    }

    public void OpenInspector() //to be called when clicking the 'inspect' button
    {
        if (!inspectorOpen)
        {
            inspectorMenu.transform.DOMove(inspectorSnapIn.position, moveSpeed);
            inspectorOpen = true;
        } else Debug.Log("inspector is already open");
    }

    public void CloseInspector() //to be called when clicking 'x' on the inspector menu
    {
        if (inspectorOpen)
        { 
            inspectorMenu.transform.DOMove(inspectorSnapOut.position, moveSpeed); //should i be doing (moveSpeed * Time.deltaTime)? tbd
            inspectorOpen = false;
        } else Debug.Log("inspector already closed");
    }

    public void OpenChecklist() //open menu after clicking checklist icon
    {
        if (!checklistOpen)
        {
            checklistMenu.transform.DOMove(checklistSnapIn.position, moveSpeed);
            checklistOpen = true;
        } else Debug.Log("checklist already open");
    }

    public void CloseChecklist() //close checklist menu after clicking 'x'
    {
        if (checklistOpen)
        {
            checklistMenu.transform.DOMove(checklistSnapOut.position, moveSpeed);
            Cursor.SetCursor(null, Vector2.down, CursorMode.Auto);
            checklistOpen = false;
        } else Debug.Log("checklist already closed");
    }

    
}
