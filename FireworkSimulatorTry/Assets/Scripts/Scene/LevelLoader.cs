using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        
        SceneManager.LoadScene(name);
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
