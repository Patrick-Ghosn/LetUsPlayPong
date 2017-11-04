using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    public BallController ballController;
    public int winningScore = 10;

    private bool isPlayerTurn = true;    
    private int playerScoreCount = 0;
    private int aiScoreCount = 0;
    
    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    public void StartTurn()
    {
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
        isPlayerTurn = true;
    }

    private void HandlePlayerScoring()
    {
        playerScoreCount++;
        isPlayerTurn = false;
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
