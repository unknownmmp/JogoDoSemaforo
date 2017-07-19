using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour {

    float t = 0f;
    float newTime;
    int transitionState = 1;
    int WaitTimeEnd = 0;
    Color black = new Vector4(0, 0, 0, 1);
    Color transparent = new Vector4(0, 0, 0, 0);

    public Button continueButton;
    public Text instText;
    int state = 0;
    string text0 = "As regras são simples...";
    string text1 = "Em cada jogada, podes fazer uma de três coisas: \r\n Colocar uma peça verde num local vazio\r\n Substituir uma peça verde por uma amarela\r\n Substituir uma peça amarela por uma vermelha";
    string text2 = "Depois de colocares a peça, já não a podes retirar.";
    string text3 = "O jogador que conseguir fazer 3 em linha com peças da mesma cor, ganha.";
    string text4 = "Simples, não é?";
    string text5 = "Vamos começar!";

    private void Start()
    {

    }


    private void Update()
    {
        if(state != 6)
        {
            CheckState();
            CheckTime();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Nicknames");
        }
    }
    
    void CheckTime()
    {
        if (WaitTime(5) == 1)
        {
            transitionState = 0;
            state++;
        }
    }

    void CheckState()
    {
        if (state == 0) TransitionText(text0);
        else if (state == 1) TransitionText(text1);
        else if (state == 2) TransitionText(text2);
        else if (state == 3) TransitionText(text3);
        else if (state == 4) TransitionText(text4);
        else if (state == 5)
        {
            TransitionText(text5);
            continueButton.interactable = true;
        }
    }

    void TransitionText(string text)
    {
        if (transitionState == 0)
        {
            t += 2f * Time.deltaTime;
            instText.color = Color.Lerp(black, transparent, Mathf.Lerp(0, 1, t));
            if (t >= 1)
            {
                transitionState = 1;
                t = 0f;
            }
        }
        else if (transitionState == 1)
        {
            instText.text = text;
            t += 2f * Time.deltaTime;
            instText.color = Color.Lerp(transparent, black, Mathf.Lerp(0, 1, t));
            if (t >= 1)
            {
                transitionState = 2;
                t = 0f;
            }
        }
    }

    int WaitTime(float time)
    {
        if (WaitTimeEnd == 0)
        {
            Debug.Log("WaitTimeEnd = 1");
            WaitTimeEnd = 1;
            newTime = Time.time + time;
            return 0;
        }
        else if (Time.time >= newTime)
        {
            Debug.Log("WaitTimeEnd = 0");
            WaitTimeEnd = 0;
            return 1;
        }
        else return 0; 
    }
}
