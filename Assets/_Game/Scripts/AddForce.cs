using UnityEngine;

public class AddForce : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    public void Apply(float force)
    {
        rb.AddForce(new Vector3(0,force,0));
    }
}
