using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameObject walls;
	public GameObject goal;
	public GameObject part;
	public List<GameObject> body;
	public float steep;
    private float xsteep;
    private float ysteep;
    private Vector2 pos;
    public bool vertical=false;
   
    void Start()
    {
        Instantiate(walls, transform.position, Quaternion.identity);
        body = new List<GameObject>();
        MakeGoal();
        InvokeRepeating("Move", 0.2f, 0.2f);
    }

    private void MakeGoal(){
    	int x=Random.Range(-4,4);
    	int y=Random.Range(-3,3);
    	Instantiate(goal, new Vector2(x,y), Quaternion.identity);
    }

    private void Move(){
    	 pos =transform.position;
         transform.position = new Vector2(transform.position.x+xsteep,transform.position.y+ysteep);
         MoveBody(); 
    }

    private void AddPart(){

  	    GameObject partClone = Instantiate(part,pos, Quaternion.identity);
    	body.Insert(0,partClone);
    	if(body.Count==2){AddPart();}
    }


    private void MoveBody(){
    	if(body.Count>0){
    	    body[0].transform.position=pos;

    	    for(int i=body.Count-1;i>0;i--){
    		   body[i].transform.position=body[i-1].transform.position;
    	   }
       }
    }


    private void OnTriggerEnter2D(Collider2D other){
    	
    	if(other.tag=="goal"){
    		Debug.Log("goaaaal");
    		AddPart();
    		Destroy(other.gameObject);
    		MakeGoal();
    	}
    	else{
    		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    	}
    }


    
    private void Update()
    {
    	
    	if(vertical){

    	  if(Input.GetAxis("Horizontal")>0)
    		{xsteep=steep; ysteep=0;vertical = false;}

    	  else if(Input.GetAxis("Horizontal")<0)
    		{xsteep=-steep; ysteep =0;vertical = false;}
    		
    	}

    	else{

    	   if(Input.GetAxis("Vertical")>0)
    		 {ysteep=steep; xsteep=0;vertical=true;}
    	
    	   else if(Input.GetAxis("Vertical")<0)
    		 {ysteep=-steep; xsteep=0;vertical=true;}
    		
    	}
    }
}
