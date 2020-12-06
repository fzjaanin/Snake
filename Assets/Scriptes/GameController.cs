using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameObject part;
	public List<GameObject> body;
    private int xsteep;
    private int ysteep;
    private Vector2 pos;
    private bool vertical=true;
    private bool wait=false;
    private Gridd grid;
    private Walls walls;
    private Food food;
    private int x, y;
   
    void Start()
    {
        grid = new Gridd(24, 16, 0.5f, new Vector3(-6, -4)); 
        walls = new Walls(grid);
        food = new Food(grid); 
        body = new List<GameObject>();
        x = grid.Width / 2;
        y = grid.Height / 2;

        transform.position = grid.GetMiddlePosition(x,y );
        InvokeRepeating("Move", 0.2f, 0.2f);
        

    }



    private void Move(){
        x = x + xsteep;
        y = y + ysteep;
    	 pos =transform.position;
        transform.position = grid.GetMiddlePosition(x, y);
         MoveBody(); 
         wait=true;
    }

    private void AddPart(){

  	    GameObject partClone = Instantiate(part,pos, Quaternion.identity);
    	body.Insert(body.Count,partClone); 	
    }


    private void MoveBody(){
    	if(body.Count>0){
            if (body.Count > 1)
            {
                for (int i = body.Count-1; i>0; i--)
                {
                    body[i].transform.position = body[i - 1].transform.position;
                }
            }
            body[0].transform.position = pos;
       }
    }


    private void OnTriggerEnter2D(Collider2D other){
    	
    	if(other.tag=="food"){
    		AddPart();
    		Destroy(other.gameObject);
            food = new Food(grid);
    	}
    	else{
    		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    	}
    }


    
    private void Update()
    {
    	
    	if(vertical & wait){

    	  if(Input.GetAxis("Horizontal")>0)
    		{xsteep=1; ysteep=0;vertical = false; wait=false;}

    	  else if(Input.GetAxis("Horizontal")<0)
    		{xsteep=-1; ysteep =0;vertical = false;wait=false;}
    		
    	}

    	 if(!vertical&wait){

    	   if(Input.GetAxis("Vertical")>0)
    		 {ysteep=1; xsteep=0;vertical=true;wait=false;}
    	
    	   else if(Input.GetAxis("Vertical")<0)
    		 {ysteep=-1; xsteep=0;vertical=true;wait=false;}
    		
    	}
    }
}
