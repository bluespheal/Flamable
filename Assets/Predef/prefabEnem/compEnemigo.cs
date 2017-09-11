using UnityEngine;
using System.Collections;
//using System;

public class compEnemigo : MonoBehaviour {
    
    public GameObject player1;
    
	public bool facingRight = true;

    public static int TIEMPO_MAX_ACCION=11;
    
    public GameObject shot;
    public Transform shotSpawn;
    
    public Transform ownPos;
    public Vector2 searchDestroy;
    public Rigidbody2D rb2D;
    
    public int lvl =10;
    float timerAtk=0, agressive=0;
    bool shoot=false, search=false;
    
    
	// Use this for initialization
    
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        ownPos=GetComponent<Transform>();
        player1=GameObject.FindGameObjectsWithTag("Play")[0];
		Flip ();
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time-timerAtk>(TIEMPO_MAX_ACCION-lvl)){
            timerAtk=Time.time;
            agressive=Random.value*12;
            if(agressive<3){
                shoot=false;
                search=false;
            }else if(agressive<6){
                shoot=true;
                search=false;
            }else if(agressive<9){
                shoot=false;
                search=true;
            }else if(agressive<12){
                shoot=true;
                search=true;
            }
            act(shoot,search);
        }
        
        
	}

	void Flip (){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    
    void act(bool shoot, bool search){
        if(shoot){
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
			searchDestroy=new Vector2((player1.transform.position.x-ownPos.position.x),0);
        }
        if(search){
            searchDestroy=new Vector2((player1.transform.position.x-ownPos.position.x),0);
            rb2D.AddForce(Vector2.up, ForceMode2D.Impulse);
            rb2D.AddForce(searchDestroy, ForceMode2D.Impulse);
            Debug.Log(""+(player1.transform.position.x-ownPos.position.x));



        }
		if (searchDestroy.x >= 0 && !facingRight) {
			Flip ();
		}else if (searchDestroy.x <= 0 && facingRight){
			Flip ();
		}

    }
    
}
