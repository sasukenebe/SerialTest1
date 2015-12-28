using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;
using System.Text;

public class Communicate : MonoBehaviour {
	
	//Component KNOB_AND_RING_SCRIPT = KNOB_AND_RING.GetComponent<CallKnob>();
	private static bool YELLOWLEDSTATUS_COM = CallYellow.YELLOWLEDSTATUS;
	public static string STRINGFROMBOX;
	public static SerialPort sp = new SerialPort ("COM3", 115200, Parity.None, 8, StopBits.One);
	private string tString = string.Empty;
	private byte _terminator = 0x4;

	//open serial connection
	void Start () {
		sp.DtrEnable = true; //if you do not do this, the event handler method of serial receipt will not work
		sp.ReadTimeout=6;
		sp.WriteTimeout=6;
		if (!sp.IsOpen) 
		{
			sp.Open ();
			Debug.Log ("A serial port has been opened");
			sp.DiscardInBuffer();
			sp.DiscardOutBuffer();

		}

	}//end start
	
	// Update is called once per frame/// <summary>
	/// /////////////////////////////////////////////////////////////////////////////////////////////
	/// </summary>
	void Update () {
	
		if (!sp.IsOpen) {
			Debug.Log ("The serial connection has been interrupted, attempting to reconnect");
			sp.Open ();
		}

		try{
		sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
			if(sp.ReadByte()=='r')
			{
				Debug.Log("data was found, but the datareceived is not working");
			}
		}catch{}
	}//end update



	public static void sendYellow (bool YELLOWLEDSTATUS)
	{
		if (YELLOWLEDSTATUS==true) {
			sp.Write ("y1");
			Debug.Log ("YELLOW STATUS 1");
		} else {
			if(YELLOWLEDSTATUS==false)
			sp.Write ("y0");
			Debug.Log ("YELLOW STATUS 0");
		}
	}

	public static void sendGreen(bool GREENLEDSTATUS){
		if (GREENLEDSTATUS==true) {
			sp.Write ("g1");
			Debug.Log ("green STATUS 1");
		} else {
			if(GREENLEDSTATUS==false)
				sp.Write ("g0");
			Debug.Log ("green STATUS 0");
		}
	}

		public static void sendRed(bool REDLEDSTATUS){
		
		if (REDLEDSTATUS==true) {
			sp.Write ("r1");
			Debug.Log ("red STATUS 1");
		} else {
			if(REDLEDSTATUS==false)
				sp.Write ("r0");
			Debug.Log ("red STATUS 0");
		}
		}

			public static void sendBlue(bool BLUELEDSTATUS){
		if (BLUELEDSTATUS==true) {
			sp.Write ("b1");
			Debug.Log ("blue STATUS 1");
		} else {
			if(BLUELEDSTATUS==false)
				sp.Write ("b0");
			Debug.Log ("blue STATUS 0");
		}
	}
	public static void sendKnob(){
		sp.Write ("e");
		sp.Write("");
		//sp.Write(ENCODERLEDSTATUS.ToString());;
	}






	void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) 
	{
		SerialPort sp = (SerialPort) sender;
		byte[] buf = new byte[sp.BytesToRead];
		Console.WriteLine("DATA RECEIVED!");
		sp.Read(buf, 0, buf.Length);
		foreach (Byte b in buf)
		{
			//Debug.Log(b.ToString());
		}
	
	}//end of data received handler 





}//end of communicate
