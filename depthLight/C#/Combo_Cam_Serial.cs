﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

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
        // TODO WebCamTexture(string deviceName, int requestedWidth, int requestedHeight, int requestedFPS);
        usedCam = new WebCamTexture("USB2.0 PC CAMERA");
       // Debug.Log("Yo "+cams[0].name+" ---------"+ cams[0].name + " ---------------- "+ cams[1].name + " ---------");
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = usedCam;
        usedCam.Play();
        trackedObj = control.GetComponent<SteamVR_TrackedObject>();

        //Serial Read
        read = new SerialPort("COM3", 115200);
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
	
	// Update is called once per frame
	void Update () {
        float halfAng = 14.04f;
       
        if (controller.GetHairTrigger()) {
                float dist = float.Parse(read.ReadLine()) / 100f;
                // Debug.Log("Reading");
                transform.localPosition = new Vector3(0, 0, dist);
                scale = (Mathf.Tan(Mathf.PI / 180 * halfAng) * dist) * 2;
                transform.localScale = new Vector3(scale, .0000001f, scale);
            
        }
    }
}
/*
      Texture2D _TextureFromCamera = new Texture2D(GetComponent<Renderer>().material.mainTexture.width,
GetComponent<Renderer>().material.mainTexture.height);
       _TextureFromCamera.SetPixels((GetComponent<Renderer>().material.mainTexture as WebCamTexture).GetPixels());
       _TextureFromCamera.Apply();
       Debug.Log(GetComponent<MeshCollider>().bounds.size);
*/
