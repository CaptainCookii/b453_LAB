using Unity.VisualScripting;
using UnityEngine;

public class cheese : MonoBehaviour, Itriggerable
{

    public float cheesescore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onTriggerEnterAction()
    {
        cheesescore++;
        Debug.Log(cheesescore);
    }

    public void onTriggerLeaveAction()
    {
        
    }
}
