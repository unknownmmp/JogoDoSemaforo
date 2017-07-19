using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public int[,] grid = new int[3, 4];
    public Image turn1;
    public Image turn2;
    public Text player1Text;
    public Text player2Text;
    public Text player1Name;
    public Text player2Name;

    public int endGame = 0;
    int points;
    int turn;
    int[] player1Stats = new int[2]; //0-wins, 1-defeats
    int[] player2Stats = new int[2];

    Color white = new Vector4(1, 1, 1, 1);
    Color transparent = new Vector4(1, 1, 1, 0);

    // Use this for initialization
    void Start() {
        ManageScores("load");
        player1Name.text = PlayerPrefs.GetString("player1name");
        player2Name.text = PlayerPrefs.GetString("player2name");
        UpdateStats();
    }

    // Update is called once per frame
    void Update() {
        TurnIcon();
    }

    public void ChangeTurn()
    {
        if (turn == 0) turn = 1;
        else if (turn == 1) turn = 0;
    }

    void TurnIcon ()
    {
        if (turn == 0 && endGame == 0)
        {
            turn2.color = transparent;
            turn1.color = Color.Lerp(white, transparent, Mathf.PingPong(Time.time, 1));
        }
        else if (turn == 1 && endGame == 0)
        {
            turn1.color = transparent;
            turn2.color = Color.Lerp(white, transparent, Mathf.PingPong(Time.time, 1));
        }
        else if (endGame == 1)
        {
            turn2.color = transparent;
            turn1.color = transparent;
        }
    }

    bool CheckPoints()
    {
        //linhas 1 a=0 check = 1
        //linhas 2 a=1 check = 2
        //diagonais check = 3, check = 4
        /*for (int check = 0; check <= 4; check++)
        {
            if (check == 0)
            {
                for (int y = 0; y <= 3; y++) //verificar colunas
                {
                    for (int x = 0; x <= 2; x++)
                    {
                        points += grid[x, y];
                        if (points > 0) Debug.Log("points:" + points);
                    }
                    if (points == 3 || points == 300 || points == 30000 && endGame == 0) return true;
                    else points = 0;
                }
            }
            else if (check == 1 || check == 2)
            {
                int a = 0;
                if (check == 2) a = 1;
                for (int x = 0; x <= 2; x++) //verificar linhas
                {
                    for (int y = 0 + a; y <= 2 + a; y++)
                    {
                        points += grid[x, y];
                        if (points > 0) Debug.Log("points:" + points);
                    }
                    if (points == 3 || points == 300 || points == 30000 && endGame == 0) return true;
                    else points = 0;
                }
            }
        }*/
        for (int check = 0; check <= 4; check++)
        {
            int x = 0, y = 0, a = 0, yme = 0, xme = 0;
            if (check == 0)
            {
                yme = 3; xme = 2;
            }
            else if (check == 1 || check == 2)
            {
                if (check == 2) a = 1;
                yme = 2; x = 0 + a; xme = 2 + a;
            }
            for (int i = y; i <= yme; i++)
            {
                for (int o = x; o <= xme; o++)
                {
                    if (check == 0) points += grid[o, i];
                    else points += grid[i, o];
                    if (points > 0) Debug.Log("points:" + points);
                }
                if (points == 3 || points == 300 || points == 30000 && endGame == 0) return true;
                else points = 0;
            }
        }
        return false;
        
    }

    void UpdateStats()
    {
        player1Text.text = player1Stats[0] + "\r\n" + player1Stats[1];
        player2Text.text = player2Stats[0] + "\r\n" + player2Stats[1];
    }

    void ManageScores(string op)
    {
        if(op == "save")
        {
            PlayerPrefs.SetInt("player1Won", player1Stats[0]);
            PlayerPrefs.SetInt("player1Lost", player1Stats[1]);
            PlayerPrefs.SetInt("player2Won", player2Stats[0]);
            PlayerPrefs.SetInt("player2Lost", player2Stats[1]);
            PlayerPrefs.Save();
        }
        else if (op == "load")
        {
            player1Stats[0] = PlayerPrefs.GetInt("player1Won", player1Stats[0]);
            player1Stats[1] = PlayerPrefs.GetInt("player1Lost", player1Stats[1]);
            player2Stats[0] = PlayerPrefs.GetInt("player2Won", player2Stats[0]);
            player2Stats[1] = PlayerPrefs.GetInt("player2Lost", player2Stats[1]);
        }
        
    }

    public void CheckWin()
    {
        if (CheckPoints() == true)
        {
            points = 0;
            if (turn == 0)
            {
                player1Stats[0]++;
                player2Stats[1]++;
            }
            else if (turn == 1)
            {
                player2Stats[0]++;
                player1Stats[1]++;
            }
            ManageScores("save");
            UpdateStats();
            endGame = 1;
            //Debug.Log("Victory!! :)");
        }   
    }
}
