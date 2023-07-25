using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomFace : MonoBehaviour
{
    [SerializeField] private Sprite[] eyes;
    [SerializeField] private Sprite[] mouths;

    [SerializeField] private Image eye;
    [SerializeField] private Image mouth;

    private void Start()
    {
        Randomize();
    }

    private void Randomize()
    {
        int seed = Random.Range(0,eyes.Length);
        eye.sprite = eyes[seed];
        seed = Random.Range(0,mouths.Length);
        mouth.sprite = mouths[seed];
    }
}
