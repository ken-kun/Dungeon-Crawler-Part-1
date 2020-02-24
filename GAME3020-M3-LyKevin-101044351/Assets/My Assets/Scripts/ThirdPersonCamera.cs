using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 10f;
    [SerializeField] Transform Target, Player;
    float mouseX;
    float mouseY;

    [SerializeField] PlayerHealth playerHealthScript;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

       


    }

    void LateUpdate()
    {
        if (playerHealthScript.isAlive)
        {
            CameraControl();
        }

    }


    void CameraControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);

      

    }


}
