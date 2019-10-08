using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using Microsoft.Win32;

public class Combo_Cam_Serial : MonoBehaviour {
    public float scale;
    public SerialPort read;
    WebCamTexture usedCam;
    //WebCamDevice[] cams;
    public GameObject control;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    // Use this for initialization

    void Start () {
     //Camera
        //use this to find the correct camera
        //cams = WebCamTexture.devices;
        usedCam = new WebCamTexture("USB2.0 PC CAMERA");
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = usedCam;
        usedCam.Play();
        trackedObj = control.GetComponent<SteamVR_TrackedObject>();

        //Serial Read
        read = new SerialPort("COM3", 115200); 
	//Comport needs to be a port less than 10 unless us use "\\\\.\\COM58" where the number can change
        read.RtsEnable = true;
        try
        {
            read.Open();
            read.ReadTimeout = 1;
            Debug.Log("Serial port is open");
        }
        catch (Exception e)
        {
            Debug.Log("Make sure the port number is less than 10 " + e.ToString());
        }
    }
    public static string AutodetectArduinoPort() {
        List<string> comports = new List<string>();
        RegistryKey rk1 = Registry.LocalMachine;
        RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
        string temp;
        foreach (string s3 in rk2.GetSubKeyNames()) {
            RegistryKey rk3 = rk2.OpenSubKey(s3);
            foreach (string s in rk3.GetSubKeyNames()) {
                if (s.Contains("VID") && s.Contains("PID")) {
                    RegistryKey rk4 = rk3.OpenSubKey(s);
                    foreach (string s2 in rk4.GetSubKeyNames()) {
                        RegistryKey rk5 = rk4.OpenSubKey(s2);
                        if ((temp = (string)rk5.GetValue("FriendlyName")) != null && temp.Contains("CH340")) { //CH340 will need to be changed to a uniqe identifier of your serial deivice.
                            RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                            if (rk6 != null && (temp = (string)rk6.GetValue("PortName")) != null) {
                                comports.Add(temp);
                            }
                        }
                    }
                }
            }
        }
        if (comports.Count > 0) {
            foreach (string s in SerialPort.GetPortNames()) {
                if (comports.Contains(s)) {
                    Debug.Log("Port found "+s);
                    return s;
                }
            }
        }
        return "COM9";
    }
	// Update is called once per frame
    void FixedUpdate () {
        Debug.Log(usedCam.height + "  -----  " + usedCam.width);
        float halfAng = 22.79f; //Half angle of Camera
        if (controller.GetHairTrigger()) {
            try{
                read.ReadTimeout = 1;
                float dist = float.Parse(read.ReadLine()) / 100f;
                transform.localPosition = new Vector3(0, 0, dist);
                scale = (Mathf.Tan(Mathf.PI / 180 * halfAng) * dist) * 2;
                transform.localScale = new Vector3(scale, .0000001f, scale);
            }
            catch (System.Exception){
                throw;
            }
        }
    }
}
