 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool ballLaunched = false;
    bool ballInGoal = false;
    bool gameStarted = false;
    bool gameOver = false;

    public Text timerText;
    public Text gameEndText;
    public Text gameScoreText;

    int scoreP1;
    int scoreP2;
    int roundScoreP1;
    int roundScoreP2;

    public int winScore = 3;
    bool P1scored = false;
    float exitTime;

    public Camera cam;
    BallAction ball;
    PlayerController player;

    void Start()
    {
        ball = FindObjectOfType<BallAction>();
        player = FindObjectOfType<PlayerController>();
        ballLaunched = false;
        gameStarted = false;
        gameOver = false;
    }

    void FixedUpdate()
    {
        if (!ballLaunched)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ballLaunched = true;
            }
            else
            {
                Vector3 currentPlayerPos = player.transform.position;
                //BallAction.Reset();
            }
        }

        Vector3 ballPos = cam.WorldToViewportPoint(ball.transform.position);
        if (ballPos.x < 0)
        {
            ballInGoal = true;
            exitTime = Time.time;
            scoreP2++;
            //BallAction.Reset();
            ballLaunched = false;
            FixedUpdate();
        }
        else if (ballPos.x > 1)
        {
            ballInGoal = true;
            exitTime = Time.time;
            scoreP1++;
            P1scored = true;
            //BallAction.Reset();
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
        }
        else if (scoreP2 == winScore)
        {
            gameOver = true;
            gameEndText.enabled = true;
            gameEndText.text = "Player 2 Wins";
        }
    }
}