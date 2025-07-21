using System.Collections.Generic;
using UnityEngine;

public class AromaType : MonoBehaviour
{
    public enum AromaOptions
    {
        Metallic,
        Sweet,
        Herbal,
        Fishy,
        Sulfuric,
        Bloody
    }

    [SerializeField]private Sprite[] aromaSprites; 
    Dictionary<AromaOptions, Sprite> aromaSet;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aromaSet = new Dictionary<AromaOptions, Sprite>();
        aromaSet.Add(AromaOptions.Metallic, aromaSprites[0]);
        aromaSet.Add(AromaOptions.Sweet, aromaSprites[1]);
        aromaSet.Add(AromaOptions.Herbal, aromaSprites[2]);
        aromaSet.Add(AromaOptions.Fishy, aromaSprites[3]);
        aromaSet.Add(AromaOptions.Sulfuric, aromaSprites[4]);
        aromaSet.Add(AromaOptions.Bloody, aromaSprites[5]);
    }

    public Sprite GetAroma(AromaOptions aromaType)
    {
        return aromaSet[aromaType];
    }
}
