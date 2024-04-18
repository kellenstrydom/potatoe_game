using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    public Transform potato;
    public float rotateSpeed;
    public float zoomSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(potato);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.isPressed)
        {
            RotateCamera();
        }

        if (Input.mouseScrollDelta != Vector2.zero)
        {
            Debug.Log(Input.mouseScrollDelta.y);
            transform.Translate(Vector3.forward * (Input.mouseScrollDelta.y * zoomSpeed));
            if (transform.position.z > -3f) transform.position = new Vector3(0, 0, -3f);
        }
    }

    private void RotateCamera()
    {
        Vector2 mouseDelta = Mouse.current.delta.value;
        potato.RotateAround(potato.position,Vector3.up, (mouseDelta.x * -rotateSpeed));
        potato.RotateAround(potato.position,Vector3.right, (mouseDelta.y * rotateSpeed));
        // transform.RotateAround(potato.transform.position, transform.up, mouseDelta.x * rotateSpeed);
        // transform.RotateAround(potato.transform.position, transform.right, mouseDelta.y * -rotateSpeed);
    }

    public void ResetView()
    {
        potato.rotation = Quaternion.identity;
        transform.position = new Vector3(0, 0, -10);
    }
}
