using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;
using System.Text;

public class Communicate : MonoBehaviour {

	public static string STRINGFROMBOX;
	public static SerialPort sp = new SerialPort ("COM3", 115200, Parity.None, 8, StopBits.One);
	private string tString = string.Empty;
	private byte _terminator = 0x4;

	//open serial connection
	void Start () {
		sp.DtrEnable = true; //if you do not do this, the event handler method of serial receipt will not work
		sp.ReadTimeout=6;
		if (!sp.IsOpen) 
		{
			sp.Open ();
			Debug.Log ("A serial port has been opened");

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



	public static void sendYellow(){
		sp.Write("y");
	}

	public static void sendGreen(){
		sp.Write("g");
		//sp.Write("\n");
	}

	public static void sendRed(){
		sp.Write("r");
	}

	public static void sendBlue(){
		sp.Write("b");
	}
	public static void sendKnob(){
	
	}






	void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) 
	{
		SerialPort sp = (SerialPort) sender;
		byte[] buf = new byte[sp.BytesToRead];
		Console.WriteLine("DATA RECEIVED!");
		sp.Read(buf, 0, buf.Length);
		foreach (Byte b in buf)
		{
			Debug.Log(b.ToString());
		}
	
	}//end of data received handler 





}//end of communicate
