using UnityEngine;

public class ToolScript : MonoBehaviour
{
    private bool onDesk;

    public bool OnDesk()
    {
        return onDesk;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ChangeState(bool state)
    {
        onDesk = state switch
        {
            true => true,
            false => false
        };
    }

   
}
