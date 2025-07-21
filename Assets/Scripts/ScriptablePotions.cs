using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using Image = UnityEngine.UI.Image;

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
    [SerializeField] private Sprite magicFlame;
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

    public AromaType.AromaOptions GetAromas(int index)
    {
        return aromas[index];
    }

    public Sprite GetFlameSprite()
    {
        return magicFlame;
    }

    public bool IsApprovable()
    {
        return approvable;
    }
    
    
    
    


}
