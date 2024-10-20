using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<LevelLoader>().LoadLevel(levelName);
    }

   
}
