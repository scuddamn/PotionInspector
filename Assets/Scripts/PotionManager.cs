using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    // potentially unneeded if i assign the script to this object[SerializeField] private GameObject potionHolder; //empty gameobject that will hold the current potion
    [SerializeField] private List<ScriptablePotions> potionOptions;
    private ScriptablePotions currentPotion;

    [SerializeField] private GameObject[] aromaIcons;
    [SerializeField] private TextMeshProUGUI dialogueBox;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
