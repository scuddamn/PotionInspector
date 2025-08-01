using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject[] resultDisplays;
    [SerializeField] private GameObject[] endButtons;
    [SerializeField] private RectTransform[] resultSnapsON;
    [SerializeField] private RectTransform resultSnapOUT;
    [SerializeField] private RectTransform[] buttonSnaps;
    [SerializeField] private AudioClip nightJingle;
    [SerializeField] private float nightFadeInDuration = 1f;
    [SerializeField] private float resultFadeDuration = 1f;
    [SerializeField] private Sprite correctSprite;
    [SerializeField] private Sprite wrongSprite;
    
    private PotionManager potionManager;
    private ChecklistSeal checklist;
    private AudioManager audioManager;
    private bool didApprove;
    private int resultIndex = 0;

    private Image backgroundImage;

    public int ResultIndex()
    {
        return resultIndex;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        potionManager = FindFirstObjectByType<PotionManager>();
        checklist = FindFirstObjectByType<ChecklistSeal>();
        audioManager = FindFirstObjectByType<AudioManager>();
        backgroundImage = GetComponent<Image>();
        resultIndex = 0;
        foreach (var result in resultDisplays)
        {
            result.transform.position = resultSnapOUT.position; //result displays start offscreen
        }

        foreach (var button in endButtons)
        {
            button.transform.position = resultSnapOUT.position; //endscreen buttons start offscreen
        }
    }

    public void NightTransition()
    {
        //screen fades to black and then results enter frame
        audioManager.GetComponent<AudioSource>().PlayOneShot(nightJingle);
        backgroundImage.DOFade(1, nightFadeInDuration);
        Invoke(nameof(DisplayResults), nightFadeInDuration);
    }

    private void GetResult(GameObject result) //change the text of the result display to the actual player results
    {
        result.GetComponentInChildren<TMP_Text>().text = 
            $"{potionManager.CurrentPotion().GetPotionName()} = \n{potionManager.CurrentPotion().GetActualPotion()}";
        if (checklist.GetComponent<Toggle>().isOn == potionManager.CurrentPotion().IsApprovable())
        {
            result.transform.Find("Correct").GetComponent<Image>().sprite = correctSprite;
        } else if (checklist.GetComponent<Toggle>().isOn != potionManager.CurrentPotion().IsApprovable())
        {
            result.transform.Find("Correct").GetComponent<Image>().sprite = wrongSprite;
        }
    }

    IEnumerator CycleResults()
    {
        //results slide onto screen one at a time
        var index = 0;
        foreach (var resultDisplay in resultDisplays)
        {
            resultDisplays[index].transform.DOMove(resultSnapsON[index].position, resultFadeDuration);
            index++;
            yield return new WaitForSeconds(0.5f);
        }

        var buttonIndex = 0;
        foreach (var button in endButtons)
        {
            endButtons[buttonIndex].transform.DOMove(buttonSnaps[buttonIndex].position, resultFadeDuration);
            buttonIndex++;
        }
    }

    public void WriteResult()
    {
        //write whether the player correctly approved the current potion
        GetResult(resultDisplays[resultIndex]);
        resultIndex++;

    }

    public void DisplayResults()
    {
        StartCoroutine(CycleResults()); 
    }
}
