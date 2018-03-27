using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private int count;
    private int[,] array = new int[3, 3];

    void ReStart()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GUI.Label(new Rect(320 + i * 50, 50 + j * 50, 50, 50), " ");
                array[i, j] = 0;
            }
        }
        count = 0;
    }

    private void Start()
    {
        ReStart();
    }

    int Check()
    {
        for (int i = 0; i < 3; i++)
        {
            if (array[i, 0] != 0 && array[i, 0] == array[i, 1] && array[i, 0] == array[i, 2])
            {
                return array[i, 0];
            }
        }
        for (int j = 0; j < 3; j++)
        {
            if (array[0, j] != 0 && array[0, j] == array[1, j] && array[1, j] == array[2, j])
            {
                return array[0, j];
            }
        }
        if ((array[0, 0] != 0 && array[0, 0] == array[1, 1] && array[1, 1] == array[2, 2]) || (array[2, 0] == array[1, 1] && array[1, 1] == array[0, 2] && array[0, 2] != 0))
        {
            return array[1, 1];
        }
        return 0;
    }

    private void OnGUI()
    {
        
        int winner = Check();
        if (winner == 1)
        {
            GUI.Label(new Rect(370, 220, 80, 40), "X wins!");
        }
        else if (count == 9 && winner != 1)
        {
            GUI.Label(new Rect(340, 200, 140, 40), "A dead heat,please restart!");
        }
        else if (winner == -1)
        {
            GUI.Label(new Rect(370, 220, 80, 40), "O wins!");
        }
        else
        {
            for (int i = 0; i < 3; i ++)
            {
                for (int j = 0; j < 3; j ++)
                {
                    if (array[i, j] == 0)
                    {
                        if (GUI.Button(new Rect(320 + i * 50, 50 + j * 50, 50, 50), ""))
                        {
                            if (count % 2 == 0)
                            {
                                array[i, j] = 1;
                            }
                            else
                            {
                                array[i, j] = -1;
                            }
                            count++;
                        }
                    }
                    if (array[i, j] == 1)
                    {
                        GUI.Button(new Rect(320 + i * 50, 50 + j * 50, 50, 50), "X");
                    }
                    if (array[i, j] == -1)
                    {
                        GUI.Button(new Rect(320 + i * 50, 50 + j * 50, 50, 50), "O");
                    }
                }
            }
        }
        if (GUI.Button(new Rect(350, 250, 80, 40), "ReStart"))
        {
            ReStart();
        }
    }
}