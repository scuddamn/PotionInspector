using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Potion", menuName = "Scriptable Objects/ScriptablePotions")]
public class ScriptablePotions : ScriptableObject
{
    [Header("Base Information")]
    [TextArea(1, 3)]
    [SerializeField] private string potionName = "Potion name...";
    [Tooltip("Choose type based on color")] [SerializeField] private PotionType potionType;
    [SerializeField] private Sprite potionSprite;

    [Header("Customer/Merchant Name")] 
    [Tooltip("Which alchemist made the potion")] [SerializeField] private PotionMaker alchemist;
    
    [Header("Testable attributes")]
    [SerializeField] private List<AromaType.AromaOptions> aromas = new List<AromaType.AromaOptions>(3);
    [Tooltip("choose size + color of flame")][SerializeField] private Sprite magicFlame;
    [TextArea(1, 3)] [SerializeField] private string tasteEffect = "Describe the taste & effect of this potion...";
    [Tooltip("Check box if potion should be approved, leave blank if potion should be rejected")][SerializeField] private bool approvable;
    

    public string GetPotionName()
    {
        return potionName;
    }

    public Sprite GetPotionSprite()
    {
        return potionSprite;
    }

    public PotionType GetPotionType()
    {
        return potionType;
    }

    public PotionMaker GetPotionCreator()
    {
        return alchemist;
    }

    public List<AromaType.AromaOptions> GetAromas()
    {
        return aromas;
    }

    public Sprite GetFlameSprite()
    {
        return magicFlame;
    }

    public string GetTasteEffect()
    {
        return tasteEffect;
    }

    public bool IsApprovable()
    {
        return approvable;
    }
    
    
    
    


}
