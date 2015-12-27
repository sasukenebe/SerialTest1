using UnityEngine;
using System.Collections;

public class CallBlue : MonoBehaviour {
	private Light BLUELIGHT;
	public static bool BLUELEDSTATUS=false;

	void Start () {
		BLUELIGHT = GetComponent <Light>();
		BLUELIGHT.enabled = false;
		gameObject.GetComponent<Renderer> ().material.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
	 	//print("Clicked");
		BLUELEDSTATUS=!BLUELEDSTATUS;
		if (BLUELEDSTATUS) {
			gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			BLUELIGHT.enabled = true;
		} else {gameObject.GetComponent<Renderer> ().material.color = Color.white;
			BLUELIGHT.enabled = false;}

		Communicate.sendBlue();
	 }
}
