using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] private Collider creatureCollider;
    public void Die()
    {
        StartCoroutine(Kill());
    }

    public IEnumerator Kill()
    {
        //animator.SetTrigger("Dead");
        creatureCollider.enabled = false;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
