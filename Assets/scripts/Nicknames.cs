using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nicknames : MonoBehaviour {

    public InputField player1;
    public InputField player2;

    public void TakePlayerName()
    {
        PlayerPrefs.SetString("player1name", player1.text);
        PlayerPrefs.SetString("player2name", player2.text);
        if (player1.text == null) PlayerPrefs.SetString("player1name", "Jogador 1");
        else if (player2.text == null) PlayerPrefs.SetString("player2name", "Jogador 2");
        PlayerPrefs.Save();
    }
}
