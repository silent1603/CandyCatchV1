using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject liveHoder;
    public GameObject GameOverPanel;
    // Start is called before the first frame update
    int score = 0;
    int lives = 3;
    [SerializeField]bool gameOver = false;
    public Text scoreText;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
            Debug.Log(score);
        }
    }

    public void IncrementLives()
    {

    }
    public void DecreaseLive()
    {
        if (lives > 0)
        {
            lives--;
            liveHoder.transform.GetChild(lives).gameObject.SetActive(false);

        }
         if(lives <= 0)
        {
            gameOver = true;
            GameOver();
        }
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        CandySpawnS.instance.StopSpawningCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;

    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
