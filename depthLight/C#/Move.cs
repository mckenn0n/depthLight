/*
Move.cs moves any object it is attached to around in 3D space in unity3D
*/
using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    private bool dirUp = true;
    public float speed = 2.0f; //This can be changed in the unity3D editer

    void Update()
    {
        if (dirUp)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }
        if (transform.position.y >= 100f)
        {
            dirUp = false;
        }

        if (transform.position.y <= 34.71f)
        {
            dirUp = true;
        }
    }
}
            
