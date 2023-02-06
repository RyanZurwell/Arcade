using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInit : MonoBehaviour
{
    public GameObject node;
    public GameObject[,] nodeArray;

    private void Start()
    {
        nodeArray = new GameObject[19,14];
        CreateGrid();
        CheckNeighbors();
    }

    void CreateGrid()
    {
        for (int y = 0; y< 14; y++)
        {
            for (int x = 0; x < 19; x++)
            {
                GameObject tempNode = Instantiate(node, gameObject.transform);
                nodeArray[x,y] = tempNode;
                tempNode.name = "[" + (y + 1) + ", " + (x + 1) + "]";
            }
        }
    }

    void GenerateMines()
    {

    }

    void ClearMiddleGrid()
    {

    }

    void CheckNeighbors()
    {
        for (int y = 0; y < 14; y++)
        {
            for (int x = 0; x < 19; x++)
            {
                for (int i = -1; i < 1; i++)
                {
                    for (int j = -1; j < 1; j++)
                    {
                        if (!InBounds(x + j, y + i) || !nodeArray[x + j, y + i].GetComponent<Node>().isMine) continue;

                        nodeArray[x, y].GetComponent<Node>().neighborMines++;
                    }
                }
            }
        }
    }

    bool InBounds(int x, int y)
    {
        if (x < 0 || y < 0) return false;
        else if (x > 19 || y > 14) return false;

        return true;
    }
}
