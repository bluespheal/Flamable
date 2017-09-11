using UnityEngine;
using System.Collections;

public class Final : MonoBehaviour {

	public float startTime;
	private string currentTime;
	Animator anim;


	// Use this for initialization
	void Start () {
		anim.SetBool ("Muerta", true);

	}
	
	// Update is called once per frame
	void Update () {
		if (startTime <= 0) {

			Application.LoadLevel("Finalfinal");
		}

		
		startTime -= Time.deltaTime;
		//currentTime = string.Format("{0:0.0}",startTime);

	
	}
}
