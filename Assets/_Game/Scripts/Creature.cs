using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] private AudioSource deathAudio;
    [SerializeField] private RandomPitch randomPitch;
    private void Start()
    {
        //Initial Random Color
        GetComponent<ColorChange>().StartColorTransition();
    }

    [SerializeField] private Collider creatureCollider;
    public void Die()
    {
        StartCoroutine(Kill());
    }

    public IEnumerator Kill()
    {
        //animator.SetTrigger("Dead");
        creatureCollider.enabled = false;
        randomPitch.Randomize();
        deathAudio.Play();
        yield return new WaitForSeconds(3);
        CreatureSpawner.Instance.currentSpawns--;
        Destroy(gameObject);
    }
}
