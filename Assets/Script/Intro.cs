using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	
	public float startTime;
	private string currentTime;
	Animator anim;
	
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (startTime <= 0) {
			
			Application.LoadLevel("Main");
		}
		
		
		startTime -= Time.deltaTime;
		//currentTime = string.Format("{0:0.0}",startTime);
	}
}