using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameLogic : MonoBehaviour
{
    public BallController ballController;
    public Text playerScoreText;
    public Text aiScoreText;

    public int winningScore = 10;    
    private int playerScoreCount = 0;
    private int aiScoreCount = 0;
    private bool isPlayerTurn = true;
    private bool turnStarted = false;

    public bool IsPlayerTurn()
    {
        return isPlayerTurn && !turnStarted;
    }

    public void StartTurn()
    {
        turnStarted = true;
        ballController.LaunchBall(isPlayerTurn);
    }

    public void HandleGoal(string goalTag)
    { 
        switch (goalTag)
        {
            case "PlayerGoal":
                HandleAIScoring();
                break;
            case "AIGoal":
                HandlePlayerScoring();
                break;
        }

        CheckWinCondition();
    }

    private void HandleAIScoring()
    {
        aiScoreCount++;
        aiScoreText.text = aiScoreCount.ToString();
        isPlayerTurn = true;
        turnStarted = false;
    }

    private void HandlePlayerScoring()
    {
        playerScoreCount++;
        playerScoreText.text = playerScoreCount.ToString();
        isPlayerTurn = false;
        ballController.LaunchBall(isPlayerTurn);
    }

    private void CheckWinCondition()
    {
        if(playerScoreCount >= winningScore)
        {

        }
        else if(aiScoreCount >= winningScore)
        {

        }
    }
}
