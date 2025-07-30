using DG.Tweening;
using UnityEngine;

public class StampMover : MonoBehaviour
{
    [SerializeField] private RectTransform onscreenSnap;
    [SerializeField] private RectTransform offscreenSnap;
    [SerializeField] private float moveSpeed = 0.5f;
    
    private bool onDesk = false;

    public void MoveStamp()
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
    }
}
