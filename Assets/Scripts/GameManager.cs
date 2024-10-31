using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool firstPlayerTurn;

    private int[,] gameBoard;

    [SerializeField] private Sprite firstPlayerSprite;
    [SerializeField] private Sprite secondPlayerSprite;

    private bool gameOver = false;

    public Sprite GetSprite()
    {
        if(firstPlayerTurn) return firstPlayerSprite;
        else return secondPlayerSprite;
    }

    private void Start()
    {
        gameBoard = new int[3,3];
        ResetBoard();
    }

    private void ResetBoard()
    {
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
        if (firstPlayerTurn) gameBoard[x, y] = 1;
        else gameBoard[x, y] = 2;
        CheckBoard(x,y);
        if (!gameOver)
        {
            firstPlayerTurn = !firstPlayerTurn;
        }
    }

    private void CheckBoard(int x, int y)
    {
        if (gameBoard[x,0] == gameBoard[x,1] && gameBoard[x, 1] == gameBoard[x,2] && gameBoard[x, 1] != 0)
        {
            PlayerWon();
        }
        if (gameBoard[0, y] == gameBoard[1, y] && gameBoard[1, y] == gameBoard[2, y] && gameBoard[1, y] != 0)
        {
            PlayerWon();
        }
        if(x==y && gameBoard[0,0] == gameBoard[1,1] && gameBoard[1,1] == gameBoard[2,2] && gameBoard[2,2] != 0)
        {
            PlayerWon();
        }
    }

    private void PlayerWon()
    {
        gameOver = true;
    }

}
