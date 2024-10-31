using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        x = (int)transform.position.x/150 + 1;
        y = (int)transform.position.y / 150 + 1;
        Color aux = Color.white;
        aux.a = 0;
        image.color = aux;
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        if (!isVisible)
        {
            isVisible = true;
            image.color = Color.white;
            image.sprite = gameManager.GetSprite();
            gameManager.BoardChange(x,y);
        }
    }

}
