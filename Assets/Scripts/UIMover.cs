using DG.Tweening;
using UnityEngine;

public class UIMover : MonoBehaviour
{
    //script to be used for (almost) any object that moves into/out of frame on runtime
    
    [SerializeField] private Transform offscreenLoc; //offscreen snap position
    [SerializeField] private Transform onscreenLoc; //onscreen snap position

    private float moveSpeed = 2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = offscreenLoc.position; //object starts offscreen
    }

    public void MoveIntoFrame()
    {
        transform.DOMove(onscreenLoc.position, moveSpeed); //move object to onscreen position
    }
}
