using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CandleTool : MonoBehaviour
{
    [SerializeField] private RectTransform offscreenSnap;
    [SerializeField] private RectTransform onscreenSnap;
    [SerializeField] private Transform flameHolder;

    private GameObject flamePrefab;
    private GameObject currentFlame;
    private Color flameColor;

    private PotionManager potionManager;
    private GameManager gameManager;
    private AudioManager audioManager;
    private DropperTool dropper;
    private bool candleIn = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        potionManager = FindFirstObjectByType<PotionManager>();
        gameManager = FindFirstObjectByType<GameManager>();
        audioManager = FindFirstObjectByType<AudioManager>();
        dropper = FindFirstObjectByType<DropperTool>();
        transform.position = offscreenSnap.position; //start object offscreen

    }

    public void UseCandle() //called on button click
    {
        if (potionManager.HasPotion())
        {
            switch (candleIn)
            {
                case true:
                    transform.DOMove(offscreenSnap.position, 0.5f);
                    candleIn = false;
                    break;
                case false:
                    transform.DOMove(onscreenSnap.position, 0.5f);
                    candleIn = true;
                    GetFlameInfo();
                    break;
            }
        } else if (!potionManager.HasPotion())
        {
            StartCoroutine(gameManager.ShowWarning());
        }
    }

    public void GetFlameInfo()
    {
        flamePrefab = potionManager.CurrentPotion().GetFlamePrefab();
        flameColor = potionManager.CurrentPotion().GetFlameColor();
    }

    private void OnMouseDown()
    {
        if (dropper.GotDrop())
        {

            currentFlame = Instantiate(flamePrefab, flameHolder.position, Quaternion.identity, flameHolder);
            audioManager.CandleSFX();
            var flameImage = currentFlame.GetComponentInChildren<Image>();
            if (flameImage != null)
            {
                flameImage.color = flameColor;
            }

            dropper.LoseDroplet();
        }
    }
}
