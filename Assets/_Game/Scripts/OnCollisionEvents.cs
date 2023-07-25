using UnityEngine.Events;
using UnityEngine;
/// <summary>
/// This is simply boilerplate code to allow us to trigger unity events on various collisions
/// </summary>
/// 
public class OnCollisionEvents : MonoBehaviour
{
    enum CollisionType { Enter, Stay, Exit };

    public Collision collisionData;

    [SerializeField] private bool requiresTag;
    [SerializeField] private string requiredTag;

    [SerializeField] private UnityEvent onCollisionEnter;
    [SerializeField] private UnityEvent onCollisionStay;
    [SerializeField] private UnityEvent onCollisionExit;

    private void OnCollisionEnter(Collision collision)
    {
        if (requiresTag && !collision.gameObject.CompareTag(requiredTag)) return;
        collisionData = collision;
        onCollisionEnter.Invoke();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (requiresTag && !collision.gameObject.CompareTag(requiredTag)) return;
        collisionData = collision;
        onCollisionStay.Invoke();
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (requiresTag && !collision.gameObject.CompareTag(requiredTag)) return;
        collisionData = collision;
        onCollisionExit.Invoke();
    }

}
