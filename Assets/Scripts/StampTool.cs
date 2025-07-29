using UnityEngine;
using UnityEngine.UI;

public class StampTool : MonoBehaviour
{
    private static readonly int Stamp = Animator.StringToHash("stamp");
    [SerializeField] private Toggle sealToggle;
    
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StampIt()
    {
        animator.SetTrigger(Stamp);
    }

    public void Stamped()
    {
        sealToggle.isOn = true;
    }
}
