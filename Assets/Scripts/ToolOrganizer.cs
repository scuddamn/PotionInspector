using UnityEngine;

public class ToolOrganizer : MonoBehaviour
{
   [SerializeField] private Transform toolHolder;
   [SerializeField] private Transform toolMenu;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tool"))
        {
            print("tool removed");
            other.GetComponent<ToolScript>().ChangeState(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tool"))
        {
            print("tool returned");
            other.GetComponent<ToolScript>().ChangeState(false);
            
        }
    }

    public void HandleTools()
    {
        var tools = GameObject.FindGameObjectsWithTag("Tool");
        foreach (var tool in tools)
        {
            switch (tool.GetComponent<ToolScript>().OnDesk())
            {
                case true:
                    tool.transform.SetParent(toolHolder, true);
                    break;
                case false:
                    tool.transform.SetParent(toolMenu, true);
                    break;
            }
        }
        
    }
}
