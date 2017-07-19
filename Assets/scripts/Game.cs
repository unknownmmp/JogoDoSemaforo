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

    int endGame = 0;
    int points;
    int turn;
    int[] player1Stats = new int[2]; //0-wins, 1-defeats
    int[] player2Stats = new int[2];

    Color white = new Vector4(1, 1, 1, 1);
    Color transparent = new Vector4(1, 1, 1, 0);

    // Use this for initialization
    void Start() {

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
        if (turn == 0)
        {
            turn2.color = transparent;
            turn1.color = Color.Lerp(white, transparent, Mathf.PingPong(Time.time, 1));
        }
        else if (turn == 1)
        {
            turn1.color = transparent;
            turn2.color = Color.Lerp(white, transparent, Mathf.PingPong(Time.time, 1));
        }
    }

    bool CheckPoints()
    {
        for (int y = 0; y <= 3; y++) //verificar colunas
        {
            for (int x = 0; x <= 2; x++)
            {
                if (endGame == 1) grid[x, y] = 0;
                points += grid[x, y];
                //Debug.Log("points:" + points);
            }
            if (points == 3 || points == 300 || points == 30000 && endGame == 0) return true;
            else points = 0;
        }
        return false;
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
            player1Text.text = player1Stats[0] + "\r\n" + player1Stats[1];
            player2Text.text = player2Stats[0] + "\r\n" + player2Stats[1];
            endGame = 1;
            CheckPoints();
            endGame = 0;
            Debug.Log("Victory!! :)");
        }
    }
}
