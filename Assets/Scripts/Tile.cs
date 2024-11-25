using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    private GameManager gameManager;
    private Image image;
    private bool isVisible;
    private int x;
    private int y;

    private void Awake()
    {
        image = GetComponent<Image>();
        x = (int)((gameObject.transform.position.x - 660) / 300);
        y = (int)((gameObject.transform.position.y - 240) / 300);
        Color aux = Color.white;
        aux.a = 0;
        image.color = aux;
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    public void HasBeenPressed()
    {
        if (gameManager.IsGameOver()) return;
        
        if (!isVisible)
        {
            isVisible = true;
            image.color = Color.white;
            gameManager.BoardChange(x, y);
        }
    }

}
