using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public Game game;

    public Button button;
    public Sprite verde;
    public Sprite amarelo;
    public Sprite vermelho;
    Color color = new Vector4(1, 1, 1, 1);
    public Image image;
    public int X;
    public int Y;

    int state = 0;

    void Start() 
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (game.endGame == 1)
        {
            button.interactable = false;
        }
    }

    public void ButtonClicked ()
    {
        //0-nada 1-verde 2-amarelo 3-vermelho
        if(state != 3) state++;
        CheckState();
    }

    void CheckState ()
    {
        Debug.Log("DEBUG: State: " + state);
        if(state != 0)
        {
            image.color = color;
        }
        if (state == 1)
        {
            image.overrideSprite = verde;
            game.grid[X, Y] = 1;
        }
        else if (state == 2)
        {
            image.overrideSprite = amarelo;
            game.grid[X, Y] = 100;
        }
        else if (state == 3)
        {
            image.overrideSprite = vermelho;
            game.grid[X, Y] = 10000;
        }

    }
}
