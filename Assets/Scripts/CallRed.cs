using UnityEngine;
using System.Collections;



public class CallRed : MonoBehaviour {

	private Light REDLIGHT;
	public static bool REDLEDSTATUS=false;
	void Start () {
		REDLIGHT = GetComponent <Light>();
		REDLIGHT.enabled = false;
		gameObject.GetComponent<Renderer> ().material.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
	 	//print("Clicked");
		REDLEDSTATUS=!REDLEDSTATUS;
		if (REDLEDSTATUS) {
			gameObject.GetComponent<Renderer> ().material.color = Color.red;
			REDLIGHT.enabled = true;
		} else {gameObject.GetComponent<Renderer> ().material.color = Color.white;
			REDLIGHT.enabled = false;}

		Communicate.sendRed();
	 }


}//end callred
