using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {
	
	
	public GameObject player1;
	bool wl=false,wr=false;

	public float maxSpeed = 2f;
	
	Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		player1=GameObject.FindGameObjectsWithTag("Play")[0];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		wl=player1.GetComponent<Walk>().walledL;
		wr=player1.GetComponent<Walk>().walledR;

		
		float move = Input.GetAxis("Horizontal");
		
		anim.SetFloat ("Speed", Mathf.Abs (move));
		
		if(!(wl  || wr )){
			GetComponent<Rigidbody2D>().velocity = new Vector2((move*-maxSpeed), 0);
		}else{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		}
		
	}
	
}



