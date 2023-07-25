using UnityEngine.Events;
using UnityEngine;
/// <summary>
/// This is simply boilerplate code to allow us to trigger unity events on various triggers
/// </summary>
/// 
public class OnTriggerEvents : MonoBehaviour
{
    enum TriggerType { Enter, Stay, Exit };

    public Collider triggerData;

    [SerializeField] private bool requiresTag;
    [SerializeField] private string requiredTag;

    [SerializeField] private UnityEvent onTriggerEnter;
    [SerializeField] private UnityEvent onTriggerStay;
    [SerializeField] private UnityEvent onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (requiresTag && !other.gameObject.CompareTag(requiredTag)) return;
        triggerData = other;
        onTriggerEnter.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (requiresTag && !other.gameObject.CompareTag(requiredTag)) return;
        triggerData = other;
        onTriggerStay.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (requiresTag && !other.gameObject.CompareTag(requiredTag)) return;
        triggerData = other;
        onTriggerExit.Invoke();
    }
}
