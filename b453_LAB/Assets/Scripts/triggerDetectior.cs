using UnityEngine;

public class triggerDetectior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Itriggerable>(out var interactable))
        {
            interactable.onTriggerEnterAction();
        }
    }

    private void OnTriggerLeave(Collider other)
    {
        if (other.TryGetComponent<Itriggerable>(out var interactable))
        {
            interactable.onTriggerLeaveAction();
        }
    }
}
