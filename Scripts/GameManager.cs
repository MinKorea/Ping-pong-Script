using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public Text text;

    public Text gameOverText;

    public bool isGameOver = false;

    ScoreCounter blueScore;
    ScoreCounter redScore;
    GameObject gameOverUI;
   
    GameObject Player1;
  
    GameObject Player2;

    GameObject Ball;

    GameObject Canvas;

    private void Start()
    {
        blueScore = GameObject.Find("Blue Score Counter").GetComponent<ScoreCounter>();
        redScore = GameObject.Find("Red Score Counter").GetComponent<ScoreCounter>();
        gameOverUI = GameObject.Find("GameOverUI");
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        Ball = GameObject.Find("Ball");
        Canvas = GameObject.Find("Canvas");

        SetText();
    }

    private void Update()
    {
        SetText();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(redScore.score >=5 || blueScore.score >= 5)
        {
            GameOver();
        }

        
    }

    public void SetText()
    {
        text.text = blueScore.score.ToString() + " : " + redScore.score.ToString();
    }

    public void GameOver()  // 게임 끝나면 호출될 함수
    {
        isGameOver = true;

        if (blueScore.score > redScore.score)
        {
            gameOverText.color = Color.blue;
            gameOverText.text = "Blue Win!";
        }
        else
        {
            gameOverText.color = Color.red;
            gameOverText.text = "Red Win!";
        }

        gameOverUI.transform.GetChild(0).gameObject.SetActive(true);
        Player1.gameObject.SetActive(false);
        Player2.gameObject.SetActive(false);
        Ball.gameObject.SetActive(false);
        


    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        // SceneManager.LoadScene(0);
    }


}
