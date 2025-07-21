using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class CustomerMovement : MonoBehaviour
{
    private static readonly int Walk = Animator.StringToHash("walk");
    private static readonly int Down = Animator.StringToHash("down");
    private static readonly int Waiting = Animator.StringToHash("waiting");
    private static readonly int Up = Animator.StringToHash("up");
    [SerializeField] private Vector3[] approachPath = new Vector3[3];
    [SerializeField] private Vector3[] departPath = new Vector3[4];
    [SerializeField] private float approachDuration = 5f;
    [SerializeField] private float departDuration = 7f;
    private Animator animator;

    private bool helpingCustomer = false;

    private int index;

    public bool HelpingCustomer()
    {
        return helpingCustomer;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
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
        if (!helpingCustomer) return; //a customer can only depart if they have first arrived
        transform.DOLocalPath(departPath, departDuration).OnWaypointChange(DepartCallback);
        
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
                Invoke(nameof(CustomerReset), 2f);
                break;
        }
    }

   
}
