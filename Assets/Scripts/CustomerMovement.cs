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

    private int index;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    
    public void CustomerReset()
    {
        gameObject.SetActive(true);
        transform.localPosition = approachPath[0];
    }
    public void CustomerArrive()
    {
        transform.DOLocalPath(approachPath, approachDuration).OnWaypointChange(ApproachCallback);
        //customer walks up to booth

    }

    public void CustomerDepart()
    {
        transform.DOLocalPath(departPath, departDuration).OnWaypointChange(DepartCallback);
    }
    
    void ApproachCallback(int waypointIndex)
    {
        //change animation based on location
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
        //change animation based on location
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
                gameObject.SetActive(false);
                Invoke(nameof(CustomerReset), 2f);
                break;
        }
    }

   
}
