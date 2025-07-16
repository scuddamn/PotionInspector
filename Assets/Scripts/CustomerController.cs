using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    [SerializeField] private Transform pathHolder;
    private Vector3[] waypoints;
    [SerializeField] private float walkSpeed = 2f;
    private Animator animator;
    private int waypointIndex = 0;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = waypoints[waypointIndex];
    }

    private void OnEnable()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        CustomerWalk();
    }

    void GetWaypoints()
    {
        
    }

    public void CustomerWalk()
    {
        transform.DOPath(waypoints, walkSpeed);
        
        switch (waypointIndex)
        {
            case <= 1:
                animator.SetTrigger("walk");
                break;
            case 2:
                animator.SetTrigger("up");
                break;
            case 3:
                animator.SetTrigger("walk");
                break;
            case 4:
                animator.SetTrigger("down");
                break;
            case 5:
                animator.SetTrigger("walk");
                break;
            default:
                animator.SetTrigger("walk");
                break;
        }
    }


}
