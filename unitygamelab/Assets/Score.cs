using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text sceneText;
    const int DEFAULT_POINTS = 1;

    int level;
    string playerName;
    // Start is called before the first frame update
    void Start()
    {
        score = persistentData.Instance.GetScore();
        playerName = persistentData.Instance.GetName();
        level = SceneManager.GetActiveScene().buildIndex - 3;
        DisplayScore();
        sceneText.text = "Level " + (level);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("balloon").Length == 0)
        {
            AdvanceLevel();
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        persistentData.Instance.SetScore(score);
        DisplayScore();
    }
    public void AdvanceLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DisplayScore()
    {
        scoreText.text = playerName + " Score: " + score;
    }
}
