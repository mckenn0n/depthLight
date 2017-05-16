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
        /*
        if (count == SIZE) {
            Debug.Log("###################################################################################");
            count = 0;
            capped = true;
        }
        lastDistances[count] = float.Parse(read.ReadLine());
        count++;
        if (capped) {
            averageDistance = lastDistances.Sum() / SIZE;
            Debug.Log(averageDistance);
        } else {
            float sum = 0.0f;
            for (int i = 0; i < count; i++) {
                sum += lastDistances[i];
            }
            averageDistance = sum / count;
            transform.localPosition = new Vector3(0, 0, averageDistance);//need to divide by 100
            Debug.Log(averageDistance);
        }
        */
	}
}
