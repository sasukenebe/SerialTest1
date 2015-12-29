using UnityEngine;
using System.Collections;

//the following colors the led in virtual world with a light component i.e (REDLED.enabled), sets a flag i.e. REDLEDSTATUS,
//and calls a function in communicate to serially send the updated information to the real world blinky box


public class CallKnob : MonoBehaviour {
	int PREVIOUS_ENCODERLEDSTATUS=0;
	public static GameObject Ring0,Ring1,Ring2,Ring3,Ring4,Ring5,Ring6,Ring7,Ring8,Ring9,Ring10,Ring11,Ring12,Ring13,Ring14,Ring15;
	public static GameObject[] RINGARRAY; 
	public static float angle;
	public static int ENCODERLEDSTATUS=0;
	// Use this for initialization
void Start () {
		 //NAME ALL THE CHILDREN (LEDS IN RING) SO THEY CAN BE REFERENCED (I USED TAGS IN UNITY)
		INITIATECHILDREN();  //INITIATES EACH INDIVIDUAL LED SO THEY CAN BE ACCESSED
		//NAME ALL THE CHILDREN (LEDS IN RING) SO THEY CAN BE REFERENCED (I USED TAGS IN UNITY)
		RINGARRAY = new GameObject[] {Ring0,Ring1,Ring2,Ring3,Ring4,Ring5,Ring6,Ring7,Ring8,Ring9,Ring10,Ring11,Ring12,Ring13,Ring14,Ring15};

		angle = gameObject.transform.eulerAngles.z; //agle of the knob
	}//end start
	
	// Update is called once per frame
void Update () {

		//the following breaks up the circle into 16 pieces of pie. lights up corresponding led by coloring it
		for (int i = 0; i <= 15; i++) {
			if((((gameObject.transform.eulerAngles.z)<=(22.5*(i+1)))&&(gameObject.transform.eulerAngles.z)>=(i*22.5))){
				ENCODERLEDSTATUS=i;
				LIGHTRINGLED(ENCODERLEDSTATUS);
				//Debug.Log ("rotaLtion.z"+gameObject.transform.rotation.z);
				if (PREVIOUS_ENCODERLEDSTATUS != ENCODERLEDSTATUS) {
					PREVIOUS_ENCODERLEDSTATUS = ENCODERLEDSTATUS;
					Communicate.sendKnob(ENCODERLEDSTATUS);
				}
			}
			else{RINGARRAY [i].GetComponent<Renderer> ().material.color = Color.white;}
		}
}//end update


	void INITIATECHILDREN(){
		Ring0= GameObject.FindGameObjectWithTag("Ring0");Ring1= GameObject.FindGameObjectWithTag("Ring1");Ring2= GameObject.FindGameObjectWithTag("Ring2");
		Ring3= GameObject.FindGameObjectWithTag("Ring3");Ring4= GameObject.FindGameObjectWithTag("Ring4");Ring5= GameObject.FindGameObjectWithTag("Ring5");
		Ring6= GameObject.FindGameObjectWithTag("Ring6");Ring7= GameObject.FindGameObjectWithTag("Ring7");Ring8= GameObject.FindGameObjectWithTag("Ring8");
		Ring9= GameObject.FindGameObjectWithTag("Ring9");Ring10= GameObject.FindGameObjectWithTag("Ring10");Ring11= GameObject.FindGameObjectWithTag("Ring11");
		Ring12= GameObject.FindGameObjectWithTag("Ring12");Ring13 = GameObject.FindGameObjectWithTag ("Ring13");Ring14= GameObject.FindGameObjectWithTag("Ring14");
		Ring15= GameObject.FindGameObjectWithTag("Ring15");
	}

	public static void LIGHTRINGLED(int CURRENTRINGLED){
		RINGARRAY[CURRENTRINGLED].GetComponent<Renderer>().material.color = Color.green;
		//for (j = 0; jvalue <= 15; jvalue++) {							//SET ALL ELSE TO 0??
		//	if (j != CURRENTRINGLED) {
		//		RINGARRAY [j].GetComponent<Renderer> ().material.color = Color.white;
		//	}
		//}
		print("LIGHTRINGLED FUNCTION IS BEING CALLED");
	}




}//end callknob
