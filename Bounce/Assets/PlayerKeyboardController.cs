using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{
    public float rotSpeed = 50;
    public float movSpeed = 2;
    private float xRotation = 0f;
    private float yRotation = 0f;

    public CharacterController controller;


    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate() {
        RotatePlayer();
        MovePlayer();
    }

    /// <summary>
    /// Handles Player movement, triggered by Keyboard input.
    /// Note: Gravity effects are not included
    /// </summary>
    private void MovePlayer() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 forwards = new Vector3(transform.forward.x, 0, transform.forward.z);
        Vector3 rightwards = new Vector3(transform.right.x, 0, transform.right.z);

        Vector3 move_dir = Vector3.Normalize(rightwards * x + forwards * z);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            move_dir *= 2;

        controller.Move(move_dir * movSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Handles Player rotation, based on Mouse movements
    /// </summary>
    void RotatePlayer() {
        // get mouse input
        float x = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;

        // calculate rotation
        yRotation += x;
        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // apply rotation
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

}
