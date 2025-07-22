using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private Transform offscreenPos;
    [SerializeField] private Transform talkingPos;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private TMP_Text nametag;

    private bool onScreen = false;
    private TextMeshProUGUI dialogueText;
    private PotionManager potionManager;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        potionManager = FindFirstObjectByType<PotionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginInspection()
    {
        if (!onScreen)
        {
            transform.DOMove(talkingPos.position, moveSpeed);
            onScreen = true;
        }
        else
        {
            print("dialogue box already on screen");
        }

    }

    public void RetractWindow()
    {
        if (onScreen)
        {
            transform.DOMove(offscreenPos.position, moveSpeed);
            onScreen = false;
        }
        else return;
    }
    
    
}
