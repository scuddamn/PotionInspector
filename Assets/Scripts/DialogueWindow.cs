using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private Transform offscreenPos;
    [SerializeField] private Transform talkingPos;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private TextMeshProUGUI nametag;

    private bool onScreen = false;
    private TextMeshProUGUI dialogueText;
    private PotionManager potionManager;
    private Vector3 offscreenPosition;
    private Vector3 talkingPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        potionManager = FindFirstObjectByType<PotionManager>();
        offscreenPos.position = offscreenPosition;
        talkingPos.position = talkingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginInspection()
    {
        transform.DOMove(talkingPosition, moveSpeed);
    }
}
