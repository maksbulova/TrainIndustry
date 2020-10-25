using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    public float speed;
    private Rigidbody2D localRigidbody;
    public float minCamZoom, maxCamZoom, zoomSpeed;

    void Start()
    {

        localRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        localRigidbody.AddForce(movement * speed);

        //camSize -= Mathf.Clamp(Input.mouseScrollDelta.y/2, 5.0f, 20.0f);
        if ((GetComponent<Camera>().orthographicSize - Input.mouseScrollDelta.y * zoomSpeed) > minCamZoom && (GetComponent<Camera>().orthographicSize - Input.mouseScrollDelta.y * zoomSpeed) < maxCamZoom)
        {
            GetComponent<Camera>().orthographicSize -= Input.mouseScrollDelta.y * zoomSpeed;
        }
        
        

        /*
        if ()
        {
            GetComponent<Camera>().orthographicSize -= 1.0f;
        }
        else if (Input.GetKey(KeyCode.KeypadMinus))
        {
            GetComponent<Camera>().orthographicSize += 1.0f;
        } 
        */
    }
}
