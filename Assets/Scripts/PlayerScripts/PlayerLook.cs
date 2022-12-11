using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    public float xRotate = 0f;
    public float xSensitivity = 20f;
    public float ySensitivity = 20f;

    //process mouse input and maps it to follow scroll motion
    public void processLook(Vector2 input) {
        float mouseX = input.x;
        float mouseY = input.y;

        //getting camera roto for up and down and inverts it
        xRotate += (mouseY * Time.deltaTime) * ySensitivity;
        //forcing our value to be between -75 and 75
        xRotate = Mathf.Clamp(xRotate, -75f, 75f);
        //use this to transform camera
        //utilize quaternion to handle the 3D rotation
        cam.transform.localRotation = Quaternion.Euler(xRotate, 0, 0);
        //make our player rotate along with the camera and inverts camera
        transform.Rotate((Vector3.up * (mouseX * Time.deltaTime) * xSensitivity) * -1);
    }
}
