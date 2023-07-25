using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : Singleton<CreatureSpawner>
{
    [SerializeField] GameObject creaturePrefab;
    [SerializeField] private float spawnTime = 3;
    public int currentSpawns;
    [SerializeField] private int maxSpawns = 10;
    [SerializeField] Transform[] spawnPoints;

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
        int seed = Random.Range(0, spawnPoints.Length);
        Transform randomSpawn = spawnPoints[seed];
        Instantiate(creaturePrefab, randomSpawn);
        isSpawning = false;

    }
}
