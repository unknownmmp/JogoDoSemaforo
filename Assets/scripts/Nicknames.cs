using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nicknames : MonoBehaviour {

    public InputField player1;
    public InputField player2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (player1.isFocused) player2.Select();
            else if (player2.isFocused) player1.Select();
            else player1.Select();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakePlayerName();
            SceneManager.LoadScene("Game");
        }
    }

    public void TakePlayerName()
    {
        PlayerPrefs.SetString("player1name", player1.text);
        PlayerPrefs.SetString("player2name", player2.text);
        if (player1.text == "") PlayerPrefs.SetString("player1name", "Jogador 1");
        if (player2.text == "") PlayerPrefs.SetString("player2name", "Jogador 2");
        PlayerPrefs.Save();
    }
}
