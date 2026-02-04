using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class lamp : MonoBehaviour, Itriggerable
{

    [SerializeField] GameObject sun;

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
        sun.SetActive(true);
    }

    public void onTriggerLeaveAction()
    {
        sun.SetActive(false);
    }
}
