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
        // 要素数はmap.Lengthで取得
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
        // 移動可能か判断
        if (moveTo < 0 || moveTo >= map.Length) { return false; }

        // 移動先に箱があったら
        if (map[moveTo] == 2)
        {
            // 移動方向算出
            int velocity = moveTo - moveFrom;
            // playerの移動方向へ箱を移動させる
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            // 箱の移動が失敗したらplayerも移動できない
            if (success == false) { return false; }
        }

        // 移動
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }
}
