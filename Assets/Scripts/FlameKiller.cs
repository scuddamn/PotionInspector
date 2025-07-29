using UnityEngine;

public class FlameKiller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void KillFlame()
    {
        Destroy(gameObject);
    }
}
