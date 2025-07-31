using System;
using DG.Tweening;
using UnityEngine;

public class StampMover : MonoBehaviour
{
    [SerializeField] private RectTransform onscreenSnap;
    [SerializeField] private RectTransform offscreenSnap;
    [SerializeField] private float moveSpeed = 0.5f;
    
    private bool onDesk = false;
    private PotionManager potionManager;
    private GameManager gameManager;

    private void Start()
    {
        potionManager = FindFirstObjectByType<PotionManager>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    public void MoveStamp()
    {
        if (potionManager.HasPotion())
        {

            switch (onDesk)
            {
                case true:
                    transform.DOMove(offscreenSnap.position, moveSpeed);
                    onDesk = false;
                    break;
                case false:
                    transform.DOMove(onscreenSnap.position, moveSpeed);
                    onDesk = true;
                    break;
            }
        } else if (!potionManager.HasPotion())
        {
            StartCoroutine(gameManager.ShowWarning());
        }
    }
}
