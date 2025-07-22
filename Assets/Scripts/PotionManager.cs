using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    // potentially unneeded if i assign the script to this object[SerializeField] private GameObject potionHolder; //empty gameobject that will hold the current potion
    [SerializeField] private List<ScriptablePotions> potionOptions;
    private ScriptablePotions currentPotion;

    [SerializeField] private GameObject aromaDisplay;
    [SerializeField] private TextMeshProUGUI dialogueBox;
    [SerializeField] private TMP_Text nametag;
    [SerializeField] private GameObject potionInspectionIcon;
    [SerializeField] private TextMeshProUGUI inspectionText;
    
    [SerializeField] private Transform potionSnapOffscreen;
    [SerializeField] private Transform potionSnapDesk;
    [SerializeField] private float moveSpeed = 1f;
    private AromaType aromaManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPotion = potionOptions[0]; //TEMP
        transform.position = potionSnapOffscreen.position;
        aromaManager = FindFirstObjectByType<AromaType>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNewCustomer()
    {
        GetComponentInChildren<Image>().sprite = currentPotion.GetPotionSprite();
        potionInspectionIcon.GetComponent<Image>().sprite = currentPotion.GetPotionSprite();
        nametag.text = $"{currentPotion.GetPotionCreator()}";
        dialogueBox.text = $"This is my {currentPotion.GetPotionName()}";
        aromaDisplay.SetActive(false);
    }

    public void PotionGiven()
    {
        transform.DOMove(potionSnapDesk.position, moveSpeed);
    }

    public void PotionTaken()
    {
        transform.DOMove(potionSnapOffscreen.position, moveSpeed);
    }

    public void InspectPotion() //colorblind-friendly inspection method that describes the potion color
    {
        aromaDisplay.SetActive(false);
        inspectionText.text = $"{currentPotion.GetPotionType()} liquid swirls inside this bottle.";
    }

    public void DisplayAroma()
    {
        inspectionText.text = "";
        aromaDisplay.SetActive(true);
        
        List<AromaType.AromaOptions> aromas = currentPotion.GetAromas();
        
        List<Sprite> aromaIcons = new List<Sprite>();
        foreach (var aroma in aromas)
        {
            aromaIcons.Add(aromaManager.GetAroma(aroma));
        }
        
        List<Transform> aromaDisplays = new List<Transform>();
        foreach (Transform child in aromaDisplay.transform)
        {
            aromaDisplays.Add(child);
        }
        
        
        int count = 0;
        foreach (var display in aromaDisplays)
        {
            aromaDisplays[count].GetComponent<Image>().sprite = aromaIcons[count];
            count++;
        }

        if (aromaDisplays.Count != aromas.Count)
        {
            Debug.LogError("# of aromas and # of displays mismatch");
        }
        
    }
}
