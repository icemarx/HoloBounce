using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{
    public float rotSpeed = 50;
    public float movSpeed = 2;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private bool holding = false;       // true if the mouse click is being held, before release

    public CharacterController controller;          // Player character controller, responsible for being moved
    public GazeGestureManager gazeGestureManager;   // Manager that detects gestures, such as the AirTap

    public NewBallOnSelect newBallOnSelect; // Reference to the new ball on select script

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate() {
        RotatePlayer();
        MovePlayer();
        SimulateAirtap();
        NewBall();
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
    /// Keyboard shortcut for spawning a new ball.
    /// </summary>
    private void NewBall()
    {
        if (Input.GetKey(KeyCode.R))
        {
            newBallOnSelect = FindObjectOfType<NewBallOnSelect>();
            if (newBallOnSelect != null)
            {
                newBallOnSelect.OnSelect();
            }
        }
            
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

    /// <summary>
    /// Simulates the AirTap gesture, by detecting a Left Mouse Button click and
    /// then passing it to <c>GazeGestureManager</c> to handle.
    /// <see cref="GazeGestureManager.HandleAirTap"/>
    /// </summary>
    void SimulateAirtap() {
        if (Input.GetMouseButtonDown(0)) {
            // Debug.Log("Clicked");
            holding = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            // Debug.Log("Unclicked");
            holding = false;
            gazeGestureManager.HandleAirTap();

        } else if(holding) {
            // Debug.Log("Holding");
        }
    }
}
