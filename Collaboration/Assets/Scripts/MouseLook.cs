using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity_X = 75f;
    public float mouseSensitivity_Y = 100f;
    public float handItemRotation = 5f;

    public Transform playerBody;
    public Transform itemInHand;
    public Transform handHinge;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState= CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity_X * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity_Y * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        handHinge.transform.localRotation = Quaternion.Euler(xRotation/handItemRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        
    }
}
