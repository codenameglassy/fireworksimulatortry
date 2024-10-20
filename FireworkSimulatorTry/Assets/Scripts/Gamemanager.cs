using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public GameObject[] heartIcons; //three images

    public int maxHealth;
    private int currentHealth;

    // List of GameObjects to be handled for BG.
    public List<GameObject> backgroundsImg;

    public GameObject gameoverPanel;
    bool gameover = false;
    public CanvasGroup fade;


    //tween
    public RectTransform currentScoreRect;
    public RectTransform highScoreRect;
    public RectTransform pauseRect;
    public RectTransform heartsRect;
    public Vector2 currentScorePos;
    public Vector2 highScorePos;
    public Vector2 pausePos;
    public Vector2 heartsPos;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        fade.alpha = 1.0f;
        fade.DOFade(0, 2f);
        gameover = false;
        currentHealth = maxHealth;

        // Ensure all objects are inactive at the start
        foreach (GameObject obj in backgroundsImg)
        {
            obj.SetActive(false);
        }

        // Randomly select one to activate
        int randomIndex = Random.Range(0, backgroundsImg.Count);
        backgroundsImg[randomIndex].SetActive(true);

        StartCoroutine(Enum_Tween());
    }

    IEnumerator Enum_Tween()
    {

        yield return new WaitForSeconds(.1f);
        currentScoreRect.DOAnchorPos(currentScorePos, 1f);
        yield return new WaitForSeconds(.5f);
        highScoreRect.DOAnchorPos(highScorePos, 1f);
        yield return new WaitForSeconds(.5f);
        pauseRect.DOAnchorPos(pausePos, .5f);
        yield return new WaitForSeconds(1f);
        heartsRect.DOAnchorPos(heartsPos, .5f);
        yield return new WaitForSeconds(1f);
    }

    public void TakeHealth()
    {
        currentHealth--;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            //gameover
            gameover = true;
            gameoverPanel.SetActive(true);
        }
           

        UpdateHealthDisplay();
    }

    public bool IsGameOver()
    {
        return gameover;
    }
    // Update the heart icons display based on the current health
    private void UpdateHealthDisplay()
    {
        // Loop through each heart icon and update visibility
        for (int i = 0; i < heartIcons.Length; i++)
        {
            if (i < currentHealth)
            {
                heartIcons[i].SetActive(true);  // Show the heart icon
            }
            else
            {
                heartIcons[i].SetActive(false); // Hide the heart icon
            }
        }
    }
}
