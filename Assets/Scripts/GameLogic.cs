using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    private bool isPlayerTurn = true;
    public BallController ballController;
    
    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    private void SwitchTurns()
    {
        isPlayerTurn = !isPlayerTurn;
    }

    public void StartTurn()
    {
        ballController.LaunchBall(isPlayerTurn);
        SwitchTurns();
    }
}
