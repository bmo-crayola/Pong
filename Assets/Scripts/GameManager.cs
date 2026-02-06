using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public int winCondition = 11;

    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI resultText;

    private int leftScore = 0;
    private int rightScore = 0;
    private bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (resultText != null)
        {
            resultText.text = "";
        }
        UpdateUI();
        ball.ResetBall(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Goal(bool leftGoalWasHit)
    {
        if (gameOver) return;

        if (leftGoalWasHit)
        {
            rightScore++;
            if (rightScore >= winCondition)
            {
                EndGame("Right Player Wins");
                return;
            }

            ball.ResetBall(-1);
        }
        else
        {
            leftScore++;
            if (leftScore >= winCondition)
            {
                EndGame("Left Player Wins");
                return;
            }

            ball.ResetBall(1);
        }

        UpdateUI();
    }

    private void EndGame(string winner)
    {
        gameOver = true;
        if (resultText != null)
        {
            resultText.text = "Game Over: " + winner;
        }

        Rigidbody rBody = ball.GetComponent<Rigidbody>();
        rBody.linearVelocity = Vector3.zero;
        rBody.angularVelocity = Vector3.zero;
    }

    private void ResetGame()
    {
        leftScore = 0;
        rightScore = 0;
        gameOver = false;

        if (resultText != null)
        {
            resultText.text = "";
        }
        UpdateUI();
        ball.ResetBall(-1);
    }

    private void UpdateUI()
    {
        if (leftScoreText != null) 
        {
            leftScoreText.text = leftScore.ToString();
        }
        if (rightScoreText != null)
        {
            rightScoreText.text = rightScore.ToString();
        }
    }
}
