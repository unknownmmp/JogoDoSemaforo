using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public Game game;

    public Sprite verde;
    public Sprite amarelo;
    public Sprite vermelho;
    public Color color;
    Color transparent = new Vector4(1, 1, 1, 0);
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
        if (game.grid[X, Y] == 0)
        {
            image.overrideSprite = null;
            image.color = transparent;
            state = 0;
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
