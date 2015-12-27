using UnityEngine;
using System.Collections;

public class CallGreen : MonoBehaviour {

	private Light GREENLIGHT;

	public static bool GREENLEDSTATUS=false;
	void Start () {
		
		GREENLIGHT = GetComponent <Light>();
		GREENLIGHT.enabled = false;
		gameObject.GetComponent<Renderer> ().material.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	 void OnMouseDown() {
	 	//print("Clicked");
		GREENLEDSTATUS=!GREENLEDSTATUS;

		if (GREENLEDSTATUS) {
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
			GREENLIGHT.enabled = true;
		} else {gameObject.GetComponent<Renderer> ().material.color = Color.white;
		  		GREENLIGHT.enabled = false;}

		Communicate.sendGreen();
	 }
}
