using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private GameObject food;
    public Food(Gridd grid)
    {
        int x = Random.Range(0, grid.Width);
        int y=Random.Range(0,grid.Height);
        food = Resources.Load<GameObject>("Prefabs/food");
        Instantiate(food, grid.GetMiddlePosition(x, y), Quaternion.identity);
    }
}
