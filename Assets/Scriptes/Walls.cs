using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private GameObject square;
    private Gridd up;
    private Gridd down;
    private Gridd left;
    private Gridd right;
  
    public  Walls(Gridd grid)
    {
        float size = grid.CellSize/2;
        square = Resources.Load<GameObject>("Prefabs/square");
        square.transform.localScale = new Vector3(2,2)*grid.CellSize;

        up = new Gridd(2*grid.Width+2, 1, size, new Vector3(grid.Origin.x-size, grid.Height*grid.CellSize+grid.Origin.y));
        down = new Gridd(2*grid.Width+2, 1,size, new Vector3(grid.Origin.x - size, grid.Origin.y-size));
        left = new Gridd(1, 2*grid.Height, size, new Vector3(grid.Origin.x - size, grid.Origin.y));
        right = new Gridd(1, 2*grid.Height, size, new Vector3(grid.Width*grid.CellSize+grid.Origin.x,grid.Origin.y));

        fillGrid(up);
        fillGrid(down);
        fillGrid(left);
        fillGrid(right);
    }

    void fillGrid(Gridd grid)
    {
        for(int x=0; x<grid.Width; x++)
        {
            for(int y=0; y<grid.Height; y++)
            {
                Instantiate(square, grid.GetMiddlePosition(x,y), Quaternion.identity);
            }
        }
    }

   
}
