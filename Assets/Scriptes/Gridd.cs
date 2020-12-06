using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gridd
{
    public int Height { get;}
    public int Width { get;}
    private int[,] tab;
    public float CellSize { get;}
    public Vector3 Origin { get;}

    public Gridd(int width, int height, float cellSize, Vector3 origin)
    {
        this.Height = height;
        this.Width = width;
        this.tab = new int[Width, Height];
        this.CellSize = cellSize;
        this.Origin = origin;

        for(int x=0; x<tab.GetLength(0); x++)
        {
            for (int y = 0; y<tab.GetLength(1); y++)
            {
                Debug.DrawLine(GetPosition(x, y), GetPosition(x, y + 1), Color.white, 30f);
                Debug.DrawLine(GetPosition(x, y), GetPosition(x+ 1, y ), Color.white, 30f);
            }

        }
        Debug.DrawLine(GetPosition(0, Height), GetPosition(Width, Height), Color.white, 30f);
        Debug.DrawLine(GetPosition(Width, 0), GetPosition(Width, Height), Color.white, 30f);
    } 

    public Vector3 GetPosition(int x, int y)
    {
        return new Vector3(x, y) * CellSize + Origin;
    }

    public Vector3 GetMiddlePosition(int x, int y)
    {
        return new Vector3(x+0.5f, y+0.5f) * CellSize + Origin; ;
    }

}
