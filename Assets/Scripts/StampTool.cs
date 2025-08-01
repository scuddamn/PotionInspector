using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StampTool : MonoBehaviour
{
   [SerializeField] private RectTransform offscreenSnap;
   [SerializeField] private float moveSpeed = 0.5f;
    
    private bool usingStamp = false;
    private Vector3 mousePosition;
    private PotionManager potionManager;
    private GameManager gameManager;
    private BookHover bookHoverZone;
    private StampAnimHandler stampAnim;
    private DropperTool dropper;

    public bool UsingStamp()
    {
        return usingStamp;
    }

    private void Start()
    {
        stampAnim = GetComponentInChildren<StampAnimHandler>();
        potionManager = FindFirstObjectByType<PotionManager>();
        gameManager = FindFirstObjectByType<GameManager>();
        bookHoverZone = FindFirstObjectByType<BookHover>();
        dropper = FindFirstObjectByType<DropperTool>();
    }

    public void EquipStamp()
    {
        if (potionManager.HasPotion())
        {

            switch (usingStamp)
            {
                case true:
                    transform.DOMove(offscreenSnap.position, moveSpeed);
                    bookHoverZone.ZoneOpen();
                    usingStamp = false;
                    break;
                case false:
                    bookHoverZone.ZoneClose();
                    usingStamp = true;
                    if (dropper.UsingDropper())
                    {
                        dropper.EquipDropper();
                    }
                    break;
            }
            
        } else if (!potionManager.HasPotion()) //cannot use stamp until player has a potion to inspect
        {
            StartCoroutine(gameManager.ShowWarning()); 
        }
    }
    
    private void Update()
    {
        if (usingStamp)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }

        if (usingStamp && Input.GetMouseButtonDown(1))
        {
            usingStamp = false;
            transform.DOMove(offscreenSnap.position, 0.5f);
        }

        if (usingStamp && Input.GetMouseButtonDown(0))
        {
            stampAnim.StampIt();
        }
    }
}
