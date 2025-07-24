using UnityEngine;

public class ToolOrganizer : MonoBehaviour
{
    public GameObject toolWarning;
    public bool toolRemoved = false;

    private GameObject[] tools;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tools = GameObject.FindGameObjectsWithTag("Tool");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tool"))
        {
            toolRemoved = true;
            
            foreach (var tool in tools)
            {
                GetComponent<Collider2D>().enabled = false; //when one tool is removed, make other tools unusable
            }

            other.GetComponent<Collider2D>().enabled = true; //make the currently removed tool still movable
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tool"))
        {
            toolRemoved = false;
            
            foreach (var tool in tools)
            {
                GetComponent<Collider2D>().enabled = true; //make all tools draggable when all tools are present
            }
        }
    }
}
