using System;
using System.Net.Mime;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class OpenBusiness : MonoBehaviour
{
    [Tooltip("time before menu fully closes")][SerializeField] private float closeDelay = 2f;

    private GameManager gameManager;
    private BookHover hoverZone;
    private TMP_Text signText;
    private BellScript bell;
    private static readonly int Fade = Animator.StringToHash("fade");

    private void Start()
    {
        GetComponent<Button>().interactable = true;
        signText = GetComponentInChildren<TMP_Text>();
        bell = FindFirstObjectByType<BellScript>();
        hoverZone = FindFirstObjectByType<BookHover>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void StartGame()
    {
        gameObject.SetActive(false); //turn off 'open stall' button
        hoverZone.ZoneOpen(); //make the guidebook interactable
        var movableObjects = GameObject.FindGameObjectsWithTag("MovableObject");
        foreach (var movableObject in movableObjects)
        {
            movableObject.GetComponent<UIMover>().MoveIntoFrame(); 
            //find all objects tagged MovableObject and call the MoveIntoFrame script on each of them
        }
        gameManager.EnableHelp();
        bell.DropBell();
    }

    public void OpenStall()
    {
        GetComponent<Button>().interactable = false;
        GetComponent<Animator>().SetTrigger(Fade);
        signText.DOFade(0f, 0.5f);
        
        Invoke(nameof(StartGame), closeDelay);
    }
}
