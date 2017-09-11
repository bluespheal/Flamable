using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	void OnGUI()
	{
		if (GUI.Button (new Rect (470, 450, 100, 50), "Empezar"))
		{
			Application.LoadLevel("1");
		}
		if (GUI.Button (new Rect (470, 510, 100, 40), "Salir"))
		{
			Application.Quit();
		}
	}



}