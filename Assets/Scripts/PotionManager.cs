using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    // potentially unneeded if i assign the script to this object[SerializeField] private GameObject potionHolder; //empty gameobject that will hold the current potion
    [SerializeField] private List<ScriptablePotions> potionOptions;
    private ScriptablePotions currentPotion;

    [SerializeField] private Transform aromaDisplay;
    [SerializeField] private TextMeshProUGUI dialogueBox;
    [SerializeField] private TMP_Text nametag;
    [SerializeField] private GameObject inspectionIcon;
    
    [SerializeField] private Transform potionSnapOffscreen;
    [SerializeField] private Transform potionSnapDesk;
    
    private AromaType aromaManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPotion = potionOptions[0];
        aromaManager = FindFirstObjectByType<AromaType>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNewCustomer()
    {
        GetComponentInChildren<Image>().sprite = currentPotion.GetPotionSprite();
        inspectionIcon.GetComponent<Image>().sprite = currentPotion.GetPotionSprite();
        nametag.text = $"{currentPotion.GetPotionCreator()}";
        dialogueBox.text = $"This is my {currentPotion.GetPotionName()}";
    }
    

    public void DisplayAroma()
    {
        List<AromaType.AromaOptions> aromas = currentPotion.GetAromas();
        
        List<Sprite> aromaIcons = new List<Sprite>();
        foreach (var aroma in aromas)
        {
            aromaIcons.Add(aromaManager.GetAroma(aroma));
        }
        
        List<Transform> aromaDisplays = new List<Transform>();
        foreach (Transform child in aromaDisplay)
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
