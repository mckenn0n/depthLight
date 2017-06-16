/*
Cam.cs is contained in Combo_Cam_Serial.cs
This Class can be used to render a video feed from a web camera onto the tecture of an an object in unity
*/
using UnityEngine;
using System.Collections;


public class Cam : MonoBehaviour {
    WebCamTexture usedCam;
    //WebCamDevice[] cams;
	void Start () {
        //use this to find the correct camera
        //cams = WebCamTexture.devices;
        usedCam = new WebCamTexture();//uses first in cams[]
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = usedCam;
        usedCam.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
