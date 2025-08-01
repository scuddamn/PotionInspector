using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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

    private bool hasPotion = false;
    private AromaType aromaManager;
    private PotionType typeManager;
    private ChecklistHandler checklist;
    private AudioManager audioManager;
    private DayNightCycle clock;
    private DropperTool dropper;

    public bool HasPotion()
    {
        return hasPotion;
    }

    public ScriptablePotions CurrentPotion()
    {
        return currentPotion;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = potionSnapOffscreen.position;
        aromaManager = FindFirstObjectByType<AromaType>();
        typeManager = FindFirstObjectByType<PotionType>();
        audioManager = FindFirstObjectByType<AudioManager>();
        checklist = FindFirstObjectByType<ChecklistHandler>();
        clock = FindFirstObjectByType<DayNightCycle>();
        dropper = FindFirstObjectByType<DropperTool>();
    }

    public void OnNewCustomer() //when bell is rung
    {
        GetRandomPotion();
        checklist.ResetChecklist(); //removes any filled-in checklist details from previous customer
        
        //reset inspection window text and aroma icons
        inspectionText.text = "Let's take a closer look...";
        aromaDisplay.SetActive(false);
        
        //change all images to match current potion
        GetComponentInChildren<Image>().sprite = currentPotion.GetPotionSprite();
        potionInspectionIcon.GetComponent<Image>().sprite = currentPotion.GetPotionSprite();
        
        //customer dialogue window changes
        nametag.text = $"{currentPotion.GetPotionCreator()}";
        dialogueBox.text = $"This is my {currentPotion.GetPotionName()}";
        
        //checklist changes
        potionName.text = $"{currentPotion.GetPotionName()}";
        alchemistName.text = $"{currentPotion.GetPotionCreator()}";
    }

    IEnumerator PotionSounds()
    {
        yield return new WaitForSeconds(moveSpeed - 0.2f);
        audioManager.PotionClink();
    }

    public void PotionGiven() //customer gives player potion
    {
        transform.DOMove(potionSnapDesk.position, moveSpeed);
        StartCoroutine(PotionSounds());
        hasPotion = true;
    }

    public void PotionTaken() //customer takes potion when they leave
    {
        transform.DOMove(potionSnapOffscreen.position, moveSpeed);
        hasPotion = false;
        clock.IncrementTimeStage(); //advance day/night cycle animation to next time of day
    }

    private void GetRandomPotion() //choose random potion from serialized list of potion options
    {
        int random = Random.Range(0, potionOptions.Count);
        currentPotion = potionOptions[random];
        potionOptions.Remove(currentPotion);
    }

    public void InspectPotion() //colorblind-friendly inspection method that describes the potion color
    {
        aromaDisplay.SetActive(false);
        inspectionText.text = $"{currentPotion.GetPotionType()} liquid swirls inside this bottle.";
    }

    public void DisplayAroma()
    {
        inspectionText.text = ""; //hide text while aroma sprites are displayed
        aromaDisplay.SetActive(true);
        
        List<AromaType.AromaOptions> aromas = currentPotion.GetAromas(); //get ref to aromas attached to current potionSO
        
        List<Sprite> aromaIcons = new List<Sprite>();
        foreach (var aroma in aromas) //get related icons for each selected aroma
        {
            aromaIcons.Add(aromaManager.GetAroma(aroma));
        }
        
        List<Transform> aromaDisplays = new List<Transform>();
        foreach (Transform child in aromaDisplay.transform) //get locations that will display each aroma icon
        {
            aromaDisplays.Add(child);
        }
        
        
        int count = 0;
        foreach (var display in aromaDisplays)
        {
            aromaDisplays[count].GetComponent<Image>().sprite = aromaIcons[count]; //change sprite to corresponding aromas
            count++;
        }

        if (aromaDisplays.Count != aromas.Count)
        {
            Debug.LogError("# of aromas and # of displays mismatch");
        }
        
    }

    public Sprite DisplayDroplet()
    {
        var potionType = currentPotion.GetPotionType();
        var typeSprite = typeManager.GetType(potionType);
        return typeSprite;
    }

    public void TastePotion()
    {
        aromaDisplay.SetActive(false);
        inspectionText.text = $"{currentPotion.GetTasteEffect()}";
    }

    private void OnMouseDown()
    {
        if (dropper.UsingDropper())
        {
            dropper.MakeDroplet();
        }
    }
}
