using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviour : MonoBehaviour
{
    private int[,] pos = new int[3, 3]; //the chess board
    private int empty = 9; //the empty position
    private int player = 1;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(280, 400, 150, 60), "Reset"))
        {
            reset();
        }

        int result = isWin();

        if (result == 1)
        {
            GUI.Label(new Rect(300, 20, 100, 50), "O wins");
        }
        else if (result == 2)
        {
            GUI.Label(new Rect(300, 20, 100, 50), "X wins");
        }
        else if (result == 3)
        {
            GUI.Label(new Rect(270, 20, 200, 50), "No one wins");
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (pos[i, j] == 1) GUI.Button(new Rect(i * 100 + 200, j * 100 + 80, 100, 100), "O");
                if (pos[i, j] == 2) GUI.Button(new Rect(i * 100 + 200, j * 100 + 80, 100, 100), "X");
                if (GUI.Button(new Rect(i * 100 + 200, j * 100 + 80, 100, 100), ""))
                {
                    if (result == 0)
                    {
                        if (player == 1) pos[i, j] = 1;
                        if (player == 2) pos[i, j] = 2;
                        --empty;
                        if (empty % 2 == 1)  player = 1;
                        else player = 2;
                    }
                }
            }
        }
    }

    public void Start()
    {
        reset();
    }

    public void reset()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                pos[i, j] = 0;
            }
        }
        empty = 9;
        player = 1;
    }
        
        int isWin()
    {
        //检查对角线和中心线
        int temp = pos[1, 1];
        if (temp != 0)
        {
            if (temp == pos[0, 0] && temp == pos[2, 2]) return temp;
            if (temp == pos[0, 2] && temp == pos[2, 0]) return temp;
            if (temp == pos[0, 1] && temp == pos[2, 1]) return temp;
            if (temp == pos[1, 0] && temp == pos[1, 2]) return temp;
        }
        //检查第一列和第一行
        temp = pos[0, 0];
        if (temp != 0)
        {
            if (temp == pos[0, 1] && temp == pos[0, 2]) return temp;
            if (temp == pos[1, 0] && temp == pos[2, 0]) return temp;
        }
        //检查第三列和第三行
        temp = pos[2, 2];
        if (temp != 0)
        {
            if (temp == pos[2, 0] && temp == pos[2, 1]) return temp;
            if (temp == pos[0, 2] && temp == pos[1, 2]) return temp;
        }
        //平局
        if (empty == 0)
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }
}
