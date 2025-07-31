using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject result1;
    [SerializeField] private GameObject result2;
    [SerializeField] private GameObject result3;
    [SerializeField] private GameObject result4;
    [SerializeField] private AudioClip nightJingle;
    [SerializeField] private float nightFadeInDuration = 1f;
    [SerializeField] private Sprite correctSprite;
    [SerializeField] private Sprite wrongSprite;
    
    private PotionManager potionManager;
    private ChecklistSeal checklist;
    private bool didApprove;

    private Image backgroundImage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        potionManager = FindFirstObjectByType<PotionManager>();
        checklist = FindFirstObjectByType<ChecklistSeal>();
        backgroundImage = GetComponent<Image>();
    }

    public void NightTransition()
    {
        //play nightJingle
        backgroundImage.DOFade(1, nightFadeInDuration);
    }

    public void GetResult(GameObject result)
    {
        result.GetComponentInChildren<TMP_Text>().text = 
            $"{potionManager.CurrentPotion().GetPotionName()} = /n{potionManager.CurrentPotion().GetActualPotion()}";
        if (checklist.GetComponent<Toggle>().isOn == potionManager.CurrentPotion().IsApprovable())
        {
            result.GetComponentInChildren<Image>().sprite = correctSprite;
        } else if (checklist.GetComponent<Toggle>().isOn != potionManager.CurrentPotion().IsApprovable())
        {
            result.GetComponentInChildren<Image>().sprite = wrongSprite;
        }
    }

    public void DisplayResult(GameObject result)
    {
        result.SetActive(true);
    }
}
