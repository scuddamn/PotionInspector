using System;
using System.Collections.Generic;
using UnityEngine;

public class PotionType : MonoBehaviour 
{

    public enum TypeOptions 
    {
        RecoveryRed,
        BodyYellow,
        MindBlue,
        ElementalGreen,
        MagicPurple,
    }

    [SerializeField] private Sprite[] typeColors;
    private Dictionary<TypeOptions, Sprite> typeSet;

    private void Start()
    {
        if (typeColors.Length != Enum.GetValues(typeof(TypeOptions)).Length)
        {
            Debug.LogError("# of colors does not match # of potion type options");
            return;
        }

        typeSet = new Dictionary<TypeOptions, Sprite>();
        for (int i = 0; i < typeColors.Length; i++)
        {
            typeSet[(TypeOptions)i] = typeColors[i];
        }
    }

    public Sprite GetType(TypeOptions potionType)
    {
        typeSet.TryGetValue(potionType, out var droplet);
        return droplet;
    }
}


