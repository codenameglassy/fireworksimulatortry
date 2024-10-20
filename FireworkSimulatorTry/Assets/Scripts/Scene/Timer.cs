using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    //[SerializeField] float currentTimer;
    [HideInInspector] public float playedTime = 0;
    //[SerializeField]TextMeshProUGUI timeGui;
    //[SerializeField] GameObject gameOverView;
    // Start is called before the first frame update
    private void OnEnable()
    {
        playedTime = 0;
    }
    // Update is called once per frame
    void Update()
    {
        playedTime += Time.deltaTime;

        /*if(currentTimer <= 0)
        {
           // gameOverView.SetActive(true);
            currentTimer = 0;
            //timeGui.text = currentTimer.ToString("0");
            return;
        }*/
        //currentTimer -= Time.deltaTime;
        //timeGui.text = currentTimer.ToString("0");
    }
}
