using UnityEngine;
using System.Collections;


public class Cam : MonoBehaviour {
    WebCamTexture usedCam;
    //WebCamDevice[] cams;
	void Start () {
        //use this to find the correct camera
        //cams = WebCamTexture.devices;
        // TODO WebCamTexture(string deviceName, int requestedWidth, int requestedHeight, int requestedFPS);
        usedCam = new WebCamTexture();//uses first in cams[] atm
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = usedCam;
        usedCam.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
