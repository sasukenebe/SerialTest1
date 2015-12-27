using UnityEngine;
using System.Collections;

public class RotateKnob : MonoBehaviour {
	
	int rotationspeed=5;
	int friction=5;
	int lerpSpeed=5;
	private float xDeg;   //used for reading mouse to rotate knob
	private float yDeg;

	private Quaternion fromRotation;
	private Quaternion toRotation;
	bool KNOBMOUSEDOWN=false;

	// Use this for initialization
	void Start () {
		
		//RINGARRAY = new GameObject[] {Ring0,Ring1,Ring2,Ring3,Ring4,Ring5,Ring6,Ring7,Ring8,Ring9,Ring10,Ring11,Ring12,Ring13,Ring14,Ring15};
	}
	// Update is called once per frame/// <summary>
	/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/// </summary>
	void Update () {


		if (KNOBMOUSEDOWN){
			xDeg -= Input.GetAxis ("Mouse X") * rotationspeed * friction;
			yDeg += Input.GetAxis ("Mouse Y") * rotationspeed * friction;
			fromRotation = transform.rotation;
			toRotation = Quaternion.Euler (0, 180, xDeg);   // our cylinder has an initial rotation of 90 on x
			///these zeros will need to be updated to the relative angle of the box, if the box is moved in the virtual environment.
			transform.rotation = Quaternion.Lerp (fromRotation, toRotation, Time.deltaTime * lerpSpeed);
		}

}// end of update

	void OnMouseDown(){
	
		KNOBMOUSEDOWN = true;
	}
	void OnMouseUp(){
		KNOBMOUSEDOWN = false;
	}



}//end of rotate knob
