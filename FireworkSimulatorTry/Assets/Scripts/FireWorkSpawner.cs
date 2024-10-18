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
        SpawnFirework(0);
        yield return new WaitForSeconds(spawnDelay);
        SpawnFirework(1);
        yield return new WaitForSeconds(spawnDelay);
        SpawnFirework(2);
        yield return new WaitForSeconds(spawnDelay);


        yield return new WaitForSeconds(waitDelay);

        StartCoroutine(SpawnFireworkRoutine());
    }

   
}
