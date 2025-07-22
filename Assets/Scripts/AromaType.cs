using System;
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
        if (aromaSprites.Length != Enum.GetValues(typeof(AromaOptions)).Length)
        {
            Debug.LogError("# of aroma sprites does not match # of aroma options");
            return;
        }

        aromaSet = new Dictionary<AromaOptions, Sprite>();
        for (int i = 0; i < aromaSprites.Length; i++)
        {
            aromaSet[(AromaOptions)i] = aromaSprites[i];
        }
    }

    public Sprite GetAroma(AromaOptions aromaType)
    {
        aromaSet.TryGetValue(aromaType, out var sprite);
        return sprite;
    }
}
