 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool ballLaunched = false;
    bool ballInGoal = false;
    bool gameStarted = false;
    bool gameOver = false;

    public Text gameEndText;
    public Text gameScoreText;
    public GameObject Ball;
    public GameObject[] Players = new GameObject[2];
    public GameObject GameOverScreen;

    int scoreP1;
    int scoreP2;
    int roundScoreP1;
    int roundScoreP2;
    int randy;

    public int winScore = 3;
    bool P1scored = false;
    float exitTime;

    public Camera cam;
    BallAction ball;
    PlayerController player;

    void Start()
    {
        ballLaunched = false;
        gameStarted = false;
        gameOver = false;
        GameOverScreen.SetActive(false);
    }

    void FixedUpdate()
    {
        randy = Random.Range(0, 2);
        gameScoreText.text = ("Red: " + scoreP2 + " || " + "Blue: " + scoreP1);
        if (!ballLaunched)
        {
            if (Input.GetButtonDown("FireP1") || Input.GetButtonDown("FireP2"))
            {
                ballLaunched = true;
                ball = Ball.GetComponent<BallAction>();
                Debug.Log("started");
                ball.speedMulti = 15f;
                ball.target = Players[randy];
                ball.Locked = false;
            }
            GameOver();
        }

        
        if (Ball.transform.position.z < -20)
        {
            ballInGoal = true;
            exitTime = Time.time;
            scoreP2++;
            ball.Reset();
            ballLaunched = false;
            FixedUpdate();
        }
        else if (Ball.transform.position.z > 17.8)
        {
            Debug.Log("p1 point");
            ballInGoal = true;
            exitTime = Time.time;
            scoreP1++;
            P1scored = true;
            ball.Reset();
            ballLaunched = false;
            FixedUpdate();
        }
    }

    void GameOver()
    {
        if (scoreP1 == winScore)
        {
            gameOver = true;
            gameEndText.enabled = true;
            gameEndText.text = "Player 1 Wins";
            gameScoreText.enabled = false;
            GameOverScreen.SetActive(true);
        }
        else if (scoreP2 == winScore)
        {
            gameOver = true;
            gameEndText.enabled = true;
            gameEndText.text = "Player 2 Wins";
            gameScoreText.enabled = false;
            GameOverScreen.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("scene reloaded");
    }
}