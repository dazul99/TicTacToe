using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private string playerOneName;
    private string playerTwoName;

    [SerializeField] private TMP_InputField inputPO;
    [SerializeField] private TMP_InputField inputPT;

    [SerializeField] private Button rbpo;
    [SerializeField] private Button lbpo;
    [SerializeField] private Button rbpt;
    [SerializeField] private Button lbpt;

    [SerializeField] private Image playerOneImage;
    [SerializeField] private Image playerTwoImage;

    [SerializeField] private Sprite[] sprites;

    private int selectedSpriteOne = 0;
    private int selectedSpriteTwo = 1;

    private DataPersistance data;

    private void Start()
    {
        playerOneImage.sprite = sprites[selectedSpriteOne];
        playerTwoImage.sprite = sprites[selectedSpriteTwo];
        data = FindObjectOfType<DataPersistance>();
    }

    public void StartGame()
    {
        playerOneName = inputPO.text;
        playerTwoName = inputPT.text;
        if(playerOneName == null || playerTwoName == null)
        {
            return;
        }
        else if(playerOneName == playerTwoName)
        {
            return;
        }

        data.SetPlayerData(playerOneName, playerTwoName, selectedSpriteOne, selectedSpriteTwo);
        data.SaveData();

        SceneManager.LoadScene(0);
    }

    public void NextSprite(bool playerOne)
    {
        if(playerOne)
        {
            PlusOne(playerOne);
            if (selectedSpriteOne == selectedSpriteTwo) PlusOne(playerOne);
            playerOneImage.sprite = sprites[selectedSpriteOne];
        }
        else
        {
            PlusOne(playerOne);
            if (selectedSpriteOne == selectedSpriteTwo) PlusOne(playerOne);
            playerTwoImage.sprite = sprites[selectedSpriteTwo];
        }



    }

    public void PrevSprite(bool playerOne)
    {
        if (playerOne)
        {
            MinusOne(playerOne);
            if (selectedSpriteOne == selectedSpriteTwo) MinusOne(playerOne);
            playerOneImage.sprite = sprites[selectedSpriteOne];
        }
        else
        {
            MinusOne(playerOne);
            if (selectedSpriteOne == selectedSpriteTwo) MinusOne(playerOne);
            playerTwoImage.sprite = sprites[selectedSpriteTwo];
        }
    }

    private void MinusOne(bool playerOne)
    {
        if (playerOne)
        {
            selectedSpriteOne--;
            if (selectedSpriteOne < 0)
            {
                selectedSpriteOne = sprites.Length - 1;
            }
        }
        else
        {
            selectedSpriteTwo--;
            if (selectedSpriteTwo < 0)
            {
                selectedSpriteTwo = sprites.Length - 1;
            }
        }
    }


    private void PlusOne(bool playerOne)
    {
        if (playerOne)
        {
            selectedSpriteOne++;
            if(selectedSpriteOne >= sprites.Length) 
            { 
                selectedSpriteOne = 0;
            }
        }
        else
        {
            selectedSpriteTwo++;
            if (selectedSpriteTwo >= sprites.Length)
            {
                selectedSpriteTwo = 0;
            }
        }
    }


}
