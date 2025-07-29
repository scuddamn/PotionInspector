using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DropperTool : MonoBehaviour
{
    [SerializeField] private float dropperFollowSpeed = 0.5f;
    [SerializeField] private GameObject droplet;
    [SerializeField] private RectTransform offscreenSnap;
    
    private PotionManager potionManager;
    private GameManager gameManager;
    private BookHover bookHover;
    private bool usingDropper = false;
    private Vector3 mousePosition;
    private bool gotDrop = false;
    private Image dropImage;
    private CandleTool candle;

    public bool GotDrop()
    {
        return gotDrop;
    }

    public bool UsingDropper()
    {
        return usingDropper;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dropImage = droplet.GetComponent<Image>();
        potionManager = FindFirstObjectByType<PotionManager>();
        gameManager = FindFirstObjectByType<GameManager>();
        bookHover = FindFirstObjectByType<BookHover>();
        candle = FindFirstObjectByType<CandleTool>();
        dropImage.enabled = false; //hide droplet
    }

    public void EquipDropper()
    {
        if (potionManager.HasPotion())
        {
            switch (usingDropper)
            {
                case true:
                    usingDropper = false;
                    bookHover.ZoneOpen();
                    transform.DOMove(offscreenSnap.position, 0.5f);
                    break;
                case false:
                    usingDropper = true;
                    bookHover.ZoneClose();
                    break;
            }
        }
        else if(!potionManager.HasPotion())
        {
            StartCoroutine(gameManager.ShowWarning());
        }
    }
    
    private void Update()
    {
        if (usingDropper)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, dropperFollowSpeed);
        }

        if (usingDropper && Input.GetMouseButtonDown(1))
        {
            usingDropper = false;
            transform.DOMove(offscreenSnap.position, 0.5f);
            dropImage.enabled = false;
        }
    }

    public void MakeDroplet()
    {
        dropImage.sprite = potionManager.DisplayDroplet();
        dropImage.enabled = true;
        gotDrop = true;
        candle.GetFlameInfo();
    }

    public void LoseDroplet()
    {
        dropImage.enabled = false;
        gotDrop = false;
    }

   
    
    
}
