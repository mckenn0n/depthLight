using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
//using System.Linq;
using System;

public class SerialRead : MonoBehaviour {
    SerialPort read;
    //static int SIZE = 20;
    //float[] lastDistances = new float[SIZE];
    //int count = 0;
    //bool capped = false;
    //float averageDistance = 0.0f;
	void Start () {
        read = new SerialPort("COM2", 115200);
        read.RtsEnable = true;

        try {
            read.Open();
            Debug.Log("Bruh, serial port is open");
        } catch(Exception e)
        {
            Debug.Log("Make sure the port number is less than 10 " + e.ToString());
        }
	}
	
	void Update () {
        transform.localPosition = new Vector3(0, 0, float.Parse(read.ReadLine()));
	}
}
