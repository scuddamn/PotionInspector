using UnityEditor.Rendering.Universal;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private GameObject tutorialRequest;
    [SerializeField] private GameObject tutorial;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void YesTutorial()
    {
        tutorialRequest.SetActive(false);
        tutorial.SetActive(true);
    }

    public void NoTutorial()
    {
        tutorialScreen.SetActive(false);
    }

    public void OpenTutorial()
    {
        tutorialScreen.SetActive(true);
        tutorialRequest.SetActive(true);
        tutorial.SetActive(false);
    }

    public void CloseTutorial()
    {
        tutorialScreen.SetActive(false);
    }
}
