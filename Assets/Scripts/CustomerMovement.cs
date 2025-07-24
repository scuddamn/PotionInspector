using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;


public class CustomerMovement : MonoBehaviour
{
    private static readonly int Walk = Animator.StringToHash("walk");
    private static readonly int Down = Animator.StringToHash("down");
    private static readonly int Waiting = Animator.StringToHash("waiting");
    private static readonly int Up = Animator.StringToHash("up");
    
    [SerializeField] private Transform[] approachPoints;
    [SerializeField] private Transform[] departPoints;
    [SerializeField] private float approachDuration = 5f;
    [SerializeField] private float departDuration = 7f;
   
    private Animator animator;
    private DialogueWindow dialogueWindow;
    private bool helpingCustomer = false;
    private bool isWaiting = false;
    private PotionManager potionManager;
    private int index;
    private Vector3[] approachPath;
    private Vector3[] departPath;

    public bool HelpingCustomer()
    {
        return helpingCustomer;
    }

    private void Awake()
    {
        dialogueWindow = FindFirstObjectByType<DialogueWindow>();
        animator = GetComponentInChildren<Animator>();
        potionManager = FindFirstObjectByType<PotionManager>();
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        approachPath = new Vector3[approachPoints.Length];
        departPath = new Vector3[departPoints.Length];
        GetWaypoints();
    }

    void GetWaypoints() //get the position values from the waypoints and put them into a vector3 array to use them with DOPath
    {
        int count = 0;
        foreach (var waypoint in approachPath)
        {
            approachPath[count] = approachPoints[count].transform.localPosition;
            count++;
        }

        int amount = 0;
        foreach (var waypoint in departPath)
        {
            departPath[amount] = departPoints[amount].transform.localPosition;
            amount++;
        }
    }
    
    public void CustomerReset()
    {
        if (!helpingCustomer) //reset customer only if they have already departed the scene
        {
            gameObject.SetActive(true);
            transform.localPosition = approachPath[0];
        } 
    }
    
    public void CustomerArrive()
    {
        //call customer to booth
        if (helpingCustomer == false)
        {
            transform.DOLocalPath(approachPath, approachDuration).OnWaypointChange(ApproachCallback);
            helpingCustomer = true;
        }
        else
        {
            print("currently helping a customer! please wait your turn");
        }
        
    }

    public void CustomerDepart()
    {
        //send customer on their way
        //to be called upon checklist completion
        
        if (!isWaiting || !helpingCustomer)
        {
            print("you can't make anyone leave yet");
        } //a customer can only depart if they have first arrived

        if (helpingCustomer && isWaiting)
        {
            transform.DOLocalPath(departPath, departDuration).OnWaypointChange(DepartCallback); 
            dialogueWindow.RetractWindow();
            potionManager.PotionTaken();
        }
    }
    
    void ApproachCallback(int waypointIndex)
    {
        //change animation based on waypoint location
            switch (waypointIndex)
            {
                case 0:
                    print("point 0");
                    break;
                case 1:
                    animator.SetTrigger(Up);
                    print("p1");
                    break;
                case 2:
                    animator.SetBool(Waiting, true);
                    isWaiting = true;
                    dialogueWindow.BeginInspection(); //formerly gave an error?? unclear why it stopped so keep an eye on it
                    potionManager.PotionGiven();
                    print("p2");
                    break;
            }
    }

    void DepartCallback(int waypointIndex)
    {
        //change animation based on waypoint location
        switch (waypointIndex)
        {
            case 0:
                animator.SetBool(Waiting, false);
                animator.SetTrigger(Walk);
                isWaiting = false;
                print("point 0");
                break;
            case 1:
                animator.SetTrigger(Down);
                print("p1");
                break;
            case 2:
                animator.SetTrigger(Walk);
                print("p2");
                break;
            case 3:
                print("end");
                helpingCustomer = false; //free the merchant to help the next customer
                gameObject.SetActive(false);
                Invoke(nameof(CustomerReset), 0.5f);
                break;
        }
    }

   
}
