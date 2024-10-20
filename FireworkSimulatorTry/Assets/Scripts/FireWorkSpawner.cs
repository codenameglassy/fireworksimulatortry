using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkSpawner : MonoBehaviour
{

    public static FireWorkSpawner instance;
    public List<GameObject> fireworkPrefab = new List<GameObject>();
    public List<Transform> fireworkSpawnPoslist = new List<Transform>();
    public float spawnDelay;
    public float waitDelay;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(SpawnFireworkRoutine());
    }
    public void SpawnFirework(int pos)
    {
        int i = Random.Range(0, fireworkPrefab.Count);
        Instantiate(fireworkPrefab[i], fireworkSpawnPoslist[pos].position, Quaternion.identity);
    }

    IEnumerator SpawnFireworkRoutine()
    {
        if (IsGameover())
        {
            yield break;
        }
        SpawnFirework(0);
        yield return new WaitForSeconds(spawnDelay);
        if (IsGameover())
        {
            yield break;
        }
        SpawnFirework(1);
        yield return new WaitForSeconds(spawnDelay);
        if (IsGameover())
        {
            yield break;
        }
        SpawnFirework(2);
        yield return new WaitForSeconds(spawnDelay);
        if (IsGameover())
        {
            yield break;
        }

        yield return new WaitForSeconds(waitDelay);
        if (IsGameover())
        {
            yield break;
        }
        StartCoroutine(SpawnFireworkRoutine());
    }

    private bool IsGameover()
    {
        return Gamemanager.instance.IsGameOver();
    }
    
}
