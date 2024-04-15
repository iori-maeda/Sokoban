using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    int[] map = { 0, 0, 0, 2, 0, 1, 0, 2, 0, 0, 2, 0, 0 };
    // Start is called before the first frame update
    void Start()
    {
        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int playerIndex = GetPlayerIndex();
            MoveNumber(1, playerIndex, playerIndex + 1);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int playerIndex = GetPlayerIndex();
            MoveNumber(1, playerIndex, playerIndex - 1);
            PrintArray();
        }
    }

    private void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ", ";
        }
        Debug.Log(debugText);
    }

    private int GetPlayerIndex()
    {
        // �v�f����map.Length�Ŏ擾
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    private bool MoveNumber(int number, int moveFrom, int moveTo)
    {
        // �ړ��\�����f
        if (moveTo < 0 || moveTo >= map.Length) { return false; }

        // �ړ���ɔ�����������
        if (map[moveTo] == 2)
        {
            // �ړ������Z�o
            int velocity = moveTo - moveFrom;
            // player�̈ړ������֔����ړ�������
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            // ���̈ړ������s������player���ړ��ł��Ȃ�
            if (success == false) { return false; }
        }

        // �ړ�
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }
}
