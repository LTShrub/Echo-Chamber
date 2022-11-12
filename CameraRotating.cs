using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotating : MonoBehaviour
{
    public float sensitivity = 5f;
    float xRotation;
    float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yRotation += (sensitivity * Input.GetAxis("Mouse X"));
        xRotation += (sensitivity * Input.GetAxis("Mouse Y") * -1);
        transform.localEulerAngles = new Vector3(xRotation, yRotation, 0);
    }
}
