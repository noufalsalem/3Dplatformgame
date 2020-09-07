using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCameraMovement : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 1;
    [SerializeField] public Transform Target, Player;
    public float mouseX, mouseY;
    public static TPSCameraMovement instance;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        
    }

    private void LateUpdate()
    {
        CamControl();
    }

    // Update is called once per frame
    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
