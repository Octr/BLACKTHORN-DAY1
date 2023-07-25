using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : Singleton<CreatureSpawner>
{
    [SerializeField] GameObject creaturePrefab;
    [SerializeField] private float spawnTime = 3;
    public int currentSpawns;
    [SerializeField] private int maxSpawns = 10;

    private bool isSpawning;

    public void Update()
    {
        if (isSpawning) return;
        if (currentSpawns >= maxSpawns) return;
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        isSpawning = true;
        yield return new WaitForSeconds(spawnTime);
        currentSpawns++;
        Instantiate(creaturePrefab, transform);
        isSpawning = false;

    }
}
