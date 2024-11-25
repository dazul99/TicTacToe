using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button restartButton;

    [SerializeField] private TextMeshProUGUI playerOneText;
    [SerializeField] private TextMeshProUGUI playerTwoText;

    [SerializeField] private TextMeshProUGUI victoryText;

    [SerializeField] private Image PlayerOneImage;
    [SerializeField] private Image PlayerTwoImage;

    [SerializeField] private Sprite playerOneSprite;
    [SerializeField] private Sprite playerTwoSprite;

    [SerializeField] private Sprite[] sprites;

    private string playerOneName;
    private string playerTwoName;

    private Color playerOneColor;
    private Color playerTwoColor;
    private Color drawColor;

    [SerializeField] private Image[] gridImagesNotInOrder;
    private Image[,] grid;

    [SerializeField] private Image VerticalBar;
    [SerializeField] private Image HorizontalBar;

    private GameManager gameManager;


    private void Awake()
    {
        grid = new Image[3, 3];
        int auxX = 0;
        int auxY = 0;
        foreach(Image image in gridImagesNotInOrder)
        {
            auxX = (int)((image.gameObject.transform.position.x - 660)/ 300);
            auxY = (int)((image.gameObject.transform.position.y - 240) / 300);
            grid[auxX, auxY] = image;
        }
        drawColor = Color.white;
        drawColor.a = 0.66f;
        playerOneColor = Color.blue;
        playerOneColor.a = 0.66f;
        playerTwoColor = Color.red;
        playerTwoColor.a = 0.66f;
    }

    private void Start()
    {
        //get names and symbols

        gameManager = FindObjectOfType<GameManager>();

        gameOverPanel.SetActive(false);
    }

    public void playerWon(bool playerOne)
    {
        if (playerOne)
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

    public void ChangeTile(int x, int y, bool playerOne)
    {
        if (playerOne)
        {
            grid[x,y].sprite = playerOneSprite;
        }
        else
        {
            grid[x,y].sprite = playerTwoSprite;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void VerticalWin(int side)
    {
        VerticalBar.rectTransform.localPosition = new Vector3(side * 300, 0, 0);
        VerticalBar.gameObject.SetActive(true);
    }

    public void HorizontalWin(int height)
    {
        HorizontalBar.rectTransform.localPosition = new Vector3(0, height*300, 0);
        HorizontalBar.gameObject.SetActive(true);
    }

    public void DiagonalWin(bool upToDown)
    {
        float rot;
        if (upToDown) rot = 45f;
        else rot = -45f;
        HorizontalBar.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rot));
        HorizontalBar.gameObject.SetActive(true);

    }

    public void SetThings(string one, string two, int x, int y)
    {
        playerOneName = one; 
        playerTwoName = two;
        playerOneSprite = sprites[x];
        playerTwoSprite = sprites[y];
        PlayerOneImage.sprite = playerOneSprite;
        PlayerTwoImage.sprite = playerTwoSprite;
        playerOneText.text = playerOneName;
        playerTwoText.text = playerTwoName;
    }

    public void IsDraw()
    {
        gameOverPanel.GetComponent<Image>().color = drawColor;
        victoryText.text = "it's a draw... Lame";
        gameOverPanel.SetActive(true);

    }

}

