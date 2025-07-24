using System;
using UnityEngine;

public class StampTool : MonoBehaviour
{
    [SerializeField] private GameObject goodInk;
    [SerializeField] private GameObject badInk;

    [SerializeField] private Transform inkSnapLeft;
    [SerializeField] private Transform inkSnapRight;
    [SerializeField] private Transform inkSnapOut;

    private Collider2D blueInk;
    private Collider2D redInk;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blueInk = goodInk.GetComponent<Collider2D>();
        redInk = badInk.GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        throw new NotImplementedException();
    }
}
