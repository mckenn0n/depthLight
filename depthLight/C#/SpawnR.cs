using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnR : MonoBehaviour
{

    public GameObject cam, bottom, top, topR, topL, botL, botR;
    public bool on = true;
    public GameObject particles;
    bool triggerButtonDown = false;
    Color custColor;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    // Use this for initialization
    void Start()
    {
        particles.GetComponent<Renderer>().enabled = 
            bottom.GetComponent<Renderer>().enabled = 
            top.GetComponent<Renderer>().enabled = 
            topL.GetComponent<Renderer>().enabled = 
            topR.GetComponent<Renderer>().enabled = 
            botR.GetComponent<Renderer>().enabled = 
            botL.GetComponent<Renderer>().enabled =
        cam.GetComponent<Renderer>().enabled = false;

        trackedObj = GetComponent<SteamVR_TrackedObject>();
        //Set Color of Projection lines. (R,G,B,Alpha)
        custColor = new Color(1f, 0f, 0f, .5f);
    }

    // Update is called once per frame
    void Update()
    {

        if (on)
        {
            triggerButtonDown = controller.GetHairTrigger();

            if (triggerButtonDown)
            {
                //Debug.Log("Trigger Button Down on Right");
                cam.GetComponent<Renderer>().enabled = true;
                particles.GetComponent<Renderer>().enabled = true;
                DrawLine(trackedObj.transform.position, bottom.transform.position, custColor);
                DrawLine(trackedObj.transform.position, botR.transform.position, custColor);
                DrawLine(trackedObj.transform.position, botL.transform.position, custColor);
                DrawLine(trackedObj.transform.position, top.transform.position, custColor);
                DrawLine(trackedObj.transform.position, topL.transform.position, custColor);
                DrawLine(trackedObj.transform.position, topR.transform.position, custColor);
            }
            else if (!triggerButtonDown)
            {
                //Debug.Log("Trigger Button Up on Right");
                cam.GetComponent<Renderer>().enabled = false;
                particles.GetComponent<Renderer>().enabled = false;
            }
        }
        else
        {
            cam.GetComponent<Renderer>().enabled = false;
            particles.GetComponent<Renderer>().enabled=false;
        }

    }
    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.05f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.001f;
        lr.endWidth = 0.001f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}

