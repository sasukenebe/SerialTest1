using UnityEngine;
using System.Collections;

public class RotateKnob : MonoBehaviour {
	
	int rotationspeed=25;
	int friction=1;
	int lerpSpeed=2;
	private float xDeg;   //used for reading mouse to rotate knob
	private float yDeg;

	private Quaternion fromRotation;
	private Quaternion toRotation;
	private static float angle;
	//public static GameObject ring0;
	int[] array = {1,2,3,4,5};
	public static GameObject Ring0,Ring1,Ring2,Ring3,Ring4,Ring5,Ring6,Ring7,Ring8,Ring9,Ring10,Ring11,Ring12,Ring13,Ring14,Ring15;
	public static GameObject[] RINGARRAY; 
	bool KNOBMOUSEDOWN=false;

	// Use this for initialization
	void Start () {
		//inefficient, but too lazy to figure out a better way, just naming all the children, each led of a parent ring.
		Ring0= GameObject.FindGameObjectWithTag("Ring0");Ring1= GameObject.FindGameObjectWithTag("Ring1");Ring2= GameObject.FindGameObjectWithTag("Ring2");
		Ring3= GameObject.FindGameObjectWithTag("Ring3");Ring4= GameObject.FindGameObjectWithTag("Ring4");Ring5= GameObject.FindGameObjectWithTag("Ring5");
		Ring6= GameObject.FindGameObjectWithTag("Ring6");Ring7= GameObject.FindGameObjectWithTag("Ring7");Ring8= GameObject.FindGameObjectWithTag("Ring8");
		Ring9= GameObject.FindGameObjectWithTag("Ring9");Ring10= GameObject.FindGameObjectWithTag("Ring10");Ring11= GameObject.FindGameObjectWithTag("Ring11");
		Ring12= GameObject.FindGameObjectWithTag("Ring12");Ring13 = GameObject.FindGameObjectWithTag ("Ring13");Ring14= GameObject.FindGameObjectWithTag("Ring14");
		Ring15= GameObject.FindGameObjectWithTag("Ring15");
		angle=gameObject.transform.rotation.eulerAngles.z;

		RINGARRAY = new GameObject[] {Ring0,Ring1,Ring2,Ring3,Ring4,Ring5,Ring6,Ring7,Ring8,Ring9,Ring10,Ring11,Ring12,Ring13,Ring14,Ring15};
	}
	// Update is called once per frame/// <summary>
	/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/// </summary>
	void Update () {
		for (int i = 0; i <= 15; i++) {
			if((((gameObject.transform.eulerAngles.z)<=(22.5*(i+1)))&&(gameObject.transform.eulerAngles.z)>=(i*22.5))){
				RINGARRAY[i].GetComponent<Renderer>().material.color = Color.green;
				//Debug.Log ("rotation.z"+gameObject.transform.rotation.z);
			}
			else{RINGARRAY [i].GetComponent<Renderer> ().material.color = Color.white;}
		}

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
