using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private TextMeshProUGUI playerOneText;
    [SerializeField] private TextMeshProUGUI playerTwoText;

    private TextMeshProUGUI victoryText;

    [SerializeField] private Image PlayerOneImage;
    [SerializeField] private Image PlayerTwoImage;

    private Sprite playerOneSprite;
    private Sprite playerTwoSprite;

    private string playerOneName;
    private string playerTwoName;

    private Color playerOneColor;
    private Color playerTwoColor;

    private void Awake()
    {
        playerOneColor = Color.blue;
        playerOneColor.a = 0.66f;
        playerTwoColor = Color.red;
        playerTwoColor.a = 0.66f;
    }

    private void Start()
    {
        //get names and symbols

        playerOneText.text = playerOneName;
        playerTwoText.text = playerTwoName;
        PlayerOneImage.sprite = playerOneSprite;
        PlayerTwoImage.sprite = playerTwoSprite;

        gameOverPanel.SetActive(false);
    }

    public void playerWon(bool player)
    {
        if (player)
        {
            gameOverPanel.GetComponent<Image>().color = playerOneColor;
            victoryText.text = playerOneName + " wins!!";
        }
        else
        {
            gameOverPanel.GetComponent<Image>().color = playerTwoColor;
            victoryText.text = playerTwoName + " wins!!";
        }
        gameOverPanel.SetActive(true);
    }
}

