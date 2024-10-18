using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkSpawner : MonoBehaviour
{

    public static FireWorkSpawner instance;

    public List<Transform> fireworkSpawnPoslist = new List<Transform>();

    private void Awake()
    {
        instance = this;
    }
   
}
