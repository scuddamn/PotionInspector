using DG.Tweening;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject musicManager;
    private static readonly int Stage = Animator.StringToHash("stage");
    private Animator myAnimator;
    private int stageNo;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        stageNo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementTimeStage()
    {
        if (stageNo >= 3)
        {
            stageNo = 3; 
            musicManager.GetComponent<AudioSource>().DOFade(0, 0.5f);
           endScreen.GetComponent<EndScreen>().NightTransition();
        }
        else
        {
            stageNo++;
        }
        
        myAnimator.SetInteger(Stage,stageNo);
        
    }
}
