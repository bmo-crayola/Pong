using UnityEngine;
using TMPro;
using System.Collections;

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
            StartCoroutine(PopScore(rightScoreText));
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
            StartCoroutine(PopScore(leftScoreText));
            if (leftScore >= winCondition)
            {
                EndGame("Left Player Wins");
                return;
            }

            ball.ResetBall(1);
        }

        UpdateUI();
    }

    // changes size and color of score text gradually for a moment to give feedback on scoring
    IEnumerator PopScore(TextMeshProUGUI sideScoreText)
    {
        Vector3 originalScale = sideScoreText.transform.localScale;

        sideScoreText.color = Color.yellow;
        sideScoreText.transform.localScale = originalScale * 1.3f;
        yield return new WaitForSeconds(0.1f);
        sideScoreText.transform.localScale = originalScale * 1.4f;
        yield return new WaitForSeconds(0.1f);
        sideScoreText.transform.localScale = originalScale * 1.5f;
        yield return new WaitForSeconds(0.1f);

        yield return new WaitForSeconds(0.5f);

        sideScoreText.transform.localScale = originalScale * 1.4f;
        yield return new WaitForSeconds(0.1f);
        sideScoreText.transform.localScale = originalScale * 1.3f;
        yield return new WaitForSeconds(0.1f);
        sideScoreText.transform.localScale = originalScale * 1.2f;
        yield return new WaitForSeconds(0.1f);

        sideScoreText.color = Color.white;
        sideScoreText.transform.localScale = originalScale * 1.1f;
        yield return new WaitForSeconds(0.1f);
        sideScoreText.transform.localScale = originalScale;        
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
