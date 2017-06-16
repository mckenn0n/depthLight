using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale : MonoBehaviour {

    public GameObject parent;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float scale = parent.GetComponent<Combo_Cam_Serial>().scale/2f; //Scales with the parent object
        transform.localScale = new Vector3(scale,scale, scale);
    }
}
