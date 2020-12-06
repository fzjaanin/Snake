using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{
    public GameObject Head { get; set; }
    public GameObject Part { get; set; }
    private List<GameObject> body;
    private int x;
    private int y;
    private Vector3 pos;
    public bool wait;

    public Snake(Gridd grid)
    {
        x = grid.Width / 2;
        y = grid.Height / 2;
        Head = Resources.Load<GameObject>("Prefabs/head");
        Part = Resources.Load<GameObject>("Prefabs/part");
        Instantiate(Head, grid.GetMiddlePosition(x, y), Quaternion.identity);
        body = new List<GameObject>();

    }

    public Snake(GameObject head, GameObject part, Gridd grid)
    {
        x = grid.Width / 2;
        y = grid.Height / 2;
        Head = head;
        Part = part;
        Instantiate(Head, grid.GetMiddlePosition(x,y), Quaternion.identity);
        body = new List<GameObject>();
    }

    public void Move(int xsteep, int ysteep, Gridd grid)
    {
        x = x + xsteep;
        y = y + ysteep;
        pos = Head.transform.position;
        Head.transform.position = grid.GetPosition(x, y);
        MoveBody();
        wait = true;
        Debug.Log(xsteep + ysteep);
    }

    private void MoveBody()
    {
        if (body.Count > 0)
        {
            if (body.Count > 1)
            {
                for (int i = body.Count - 1; i > 0; i--)
                {
                    body[i].transform.position = body[i - 1].transform.position;
                }
            }
            body[0].transform.position = pos;
        }
    }


    private void AddPart()
    {

        GameObject partClone = Instantiate(Part, pos, Quaternion.identity);
        body.Insert(body.Count, partClone);
    }

}
