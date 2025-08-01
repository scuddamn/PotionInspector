
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    
    [Header("Warning Message")]
    [SerializeField] private Image decorScroll;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private float messageFadeTime = 1f;
    [SerializeField] private float messageDuration = 4f;

    private PotionManager potionManager;
    private AudioManager audioManager;

    public bool ChecklistOpen()
    {
        return checklistOpen;
    }
    
    private void Awake()  //start game with menus offscreen
    { 
        inspectorMenu.transform.position = inspectorSnapOut.position;
        checklistMenu.transform.position = checklistSnapOut.position;
        potionManager = FindFirstObjectByType<PotionManager>();
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    private void Start()
    {
        openSign.SetActive(true);
    }

    public void OpenInspector() //to be called when clicking the 'inspect' button
    {
        if (potionManager.HasPotion() && !inspectorOpen)
        {
            inspectorMenu.transform.DOMove(inspectorSnapIn.position, moveSpeed);
            audioManager.MenuSFX();
            inspectorOpen = true;
            
        } else if (inspectorOpen)
        {
            Debug.Log("inspector is already open");
            
        } else if (!potionManager.HasPotion())
        {
            StartCoroutine(ShowWarning());
        }

        
    }

    public void CloseInspector() //to be called when clicking 'x' on the inspector menu
    {
        if (inspectorOpen)
        { 
            inspectorMenu.transform.DOMove(inspectorSnapOut.position, moveSpeed); //should I be doing (moveSpeed * Time.deltaTime)? tbd
            audioManager.MenuSFX();
            inspectorOpen = false;
        } else Debug.Log("inspector already closed");
    }

    public void OpenChecklist() //open menu after clicking checklist icon
    {
        if (!checklistOpen && potionManager.HasPotion())
        {
            checklistMenu.transform.DOMove(checklistSnapIn.position, moveSpeed);
            audioManager.PaperSFX();
            checklistOpen = true;
        } else if (checklistOpen)
        {
            Debug.Log("checklist already open");
        } else if (!potionManager.HasPotion())
        {
            StartCoroutine(ShowWarning());
        }

        
    }

    public void CloseChecklist() //close checklist menu after clicking 'x'
    {
        if (checklistOpen)
        {
            checklistMenu.transform.DOMove(checklistSnapOut.position, moveSpeed);
            audioManager.PaperSFX();
            Cursor.SetCursor(null, Vector2.down, CursorMode.Auto);
            checklistOpen = false;
        } else Debug.Log("checklist already closed");
    }

    

    public IEnumerator ShowWarning()
    {
        decorScroll.DOFade(1, messageFadeTime);
        messageText.DOFade(1, messageFadeTime);
        yield return new WaitForSeconds(messageDuration);
        decorScroll.DOFade(0, messageFadeTime);
        messageText.DOFade(0, messageFadeTime);
        yield return new WaitForSeconds(0.5f);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
