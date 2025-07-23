using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    [Header("Potions")]
    [SerializeField] private List<ScriptablePotions> potionOptions;
    private ScriptablePotions currentPotion;
    
    [Header("Dialogue")]
    [SerializeField] private TextMeshProUGUI dialogueBox;
    [SerializeField] private TMP_Text nametag;
    
    [Header("Inspection")]
    [SerializeField] private GameObject aromaDisplay;
    [SerializeField] private GameObject potionInspectionIcon;
    [SerializeField] private TextMeshProUGUI inspectionText;

    [Header("Checklist")] 
    [SerializeField] private TMP_Text potionName;
    [SerializeField] private TMP_Text alchemistName;
    
    [Header("Potion Movement")]
    [SerializeField] private Transform potionSnapOffscreen;
    [SerializeField] private Transform potionSnapDesk;
    [SerializeField] private float moveSpeed = 1f;
    
    
    private AromaType aromaManager;

    public ScriptablePotions CurrentPotion()
    {
        return currentPotion;
    }
    
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

    public void OnNewCustomer() //when bell is rung
    {
        //change all images to match current potion
        GetComponentInChildren<Image>().sprite = currentPotion.GetPotionSprite();
        potionInspectionIcon.GetComponent<Image>().sprite = currentPotion.GetPotionSprite();
        
        //customer dialogue window changes
        nametag.text = $"{currentPotion.GetPotionCreator()}";
        dialogueBox.text = $"This is my {currentPotion.GetPotionName()}";
        
        //checklist changes
        potionName.text = $"{currentPotion.GetPotionName()}";
        alchemistName.text = $"{currentPotion.GetPotionCreator()}";
        
        aromaDisplay.SetActive(false);
    }

    public void PotionGiven() //customer gives player potion
    {
        transform.DOMove(potionSnapDesk.position, moveSpeed);
    }

    public void PotionTaken() //customer takes potion when they leave
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
