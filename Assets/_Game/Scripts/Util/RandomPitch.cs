using UnityEngine;
/// <summary>
/// This script simply randomizes pitch between a min and max value for the audio source provided (Useful in events)
/// </summary>
public class RandomPitch : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float minPitch, maxPitch;

    public void Randomize()
    {
        float randomPitch = Random.Range(minPitch, maxPitch);
        audioSource.pitch = randomPitch;
    }
}
