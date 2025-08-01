using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject title;
    [SerializeField] private RectTransform titleSnapOUT;
    [SerializeField] private RectTransform titleSnapIN;
    [SerializeField] private float moveDuration = 1f;
    [SerializeField] private GameObject fadeEffect;
    [SerializeField] private GameObject credits;
    [SerializeField] private RectTransform creditsBottom;
    [SerializeField] private RectTransform creditsTop;
    [SerializeField] private float creditDuration = 5f;
    

    private RectTransform nextLoc;

    private void Awake()
    {
        title.transform.position = titleSnapOUT.position;
        credits.transform.position = creditsBottom.position;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(TitleUp), 1.5f);
        
    }

    void TitleUp()
    {
        title.transform.DOMove(titleSnapIN.position, moveDuration);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        fadeEffect.GetComponent<Image>().DOFade(1, 1.5f);
        Invoke(nameof(MoveToNextScene), 1.5f);
    }

    void MoveToNextScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void ShowCredits()
    {
        if (credits.transform.position == creditsBottom.position)
        {
            nextLoc = creditsTop;
        } else if (credits.transform.position == creditsTop.position)
        {
            nextLoc = creditsBottom;
        }

        StartCoroutine(MoveText());


    }

    IEnumerator MoveText()
    {
        title.transform.DOMove(titleSnapOUT.position, moveDuration);
        yield return new WaitForSeconds(moveDuration);
        credits.transform.DOMove(nextLoc.position, creditDuration);
        yield return new WaitForSeconds(creditDuration + 0.5f);
        TitleUp();
    }
}
