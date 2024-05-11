using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Component")]
    public Transform body;

    [Range(50,500)] public float mouseSensitivity;
    float xRot=0f;

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Mouse();
    }
    void Mouse()
    {
        //mouse x ve y konumları
        float rotX=Input.GetAxisRaw("Mouse X")*mouseSensitivity*Time.deltaTime;
        float rotY=Input.GetAxisRaw("Mouse Y")*mouseSensitivity*Time.deltaTime;
        xRot=Mathf.Clamp(xRot,-80f,80f);

        xRot-=rotY; //kamera olduğu yerde kalmaması için bunu yapıyoruz. 
        transform.localRotation = Quaternion.Euler(xRot,0f,0f);

        

        body.Rotate(Vector3.up*rotX);
    }
}
