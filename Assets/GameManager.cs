using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Sprite verde;
    public Sprite amarelo;
    public Sprite vermelho;
    public Color color;
    public Image image;

    int state = 0;

    void Start() 
    {
        image = GetComponent<Image>(); 
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
        if (state == 1) image.overrideSprite = verde;
        else if (state == 2) image.overrideSprite = amarelo;
        else if (state == 3) image.overrideSprite = vermelho;
        else image.overrideSprite = null;

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
