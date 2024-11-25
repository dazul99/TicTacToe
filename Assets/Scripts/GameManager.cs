using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool firstPlayerTurn = true;

    private int[,] gameBoard;

    private UIManager uiManager;

    private bool gameOver = false;

    private DataPersistance dataper;
    private Data data;

    private int turnsPlayed = 0;


    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        gameBoard = new int[3,3];
        dataper = FindObjectOfType<DataPersistance>();
        data = dataper.LoadData();
        uiManager.SetThings(data.playerOneName, data.playerTwoName, data.playerOneSprite, data.playerTwoSprite);
        ResetBoard();

    }

    private void ResetBoard()
    {
        turnsPlayed = 0;
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                gameBoard[i, j] = 0;
            }
        }
    }

    public void BoardChange(int x, int y)
    {
        if (gameOver) return;
        turnsPlayed++;
        if (firstPlayerTurn) gameBoard[x, y] = 1;
        else gameBoard[x, y] = 2;
        uiManager.ChangeTile(x, y, firstPlayerTurn);
        CheckBoard(x,y);
        if (!gameOver)
        {
            firstPlayerTurn = !firstPlayerTurn;
        }
        if(turnsPlayed == 9)
        {
            uiManager.IsDraw();
        }
    }

    private void CheckBoard(int x, int y)
    {
        if (gameBoard[x,0] == gameBoard[x,1] && gameBoard[x, 1] == gameBoard[x,2] && gameBoard[x, 1] != 0)
        {
            PlayerWon();
            uiManager.VerticalWin(x - 1);
        }
        else if (gameBoard[0, y] == gameBoard[1, y] && gameBoard[1, y] == gameBoard[2, y] && gameBoard[1, y] != 0)
        {
            PlayerWon();
            uiManager.HorizontalWin(y-1);
        }
        else if(x==y && gameBoard[0,0] == gameBoard[1,1] && gameBoard[1,1] == gameBoard[2,2] && gameBoard[2,2] != 0)
        {
            PlayerWon();
            uiManager.DiagonalWin(true);
        }
        else if(gameBoard[2, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[0, 2] && gameBoard[0, 2] != 0)
        {
            PlayerWon();
            uiManager.DiagonalWin(false);

        }
    }

    private void PlayerWon()
    {
        gameOver = true;
        uiManager.playerWon(firstPlayerTurn);
    }

    public bool IsGameOver()
    {
        return gameOver;
    }


}
