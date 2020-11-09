using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{
    public GameManager gameManager;
    public static GazeGestureManager Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;

    // Use this for initialization
    void Awake()
    {
        if (gameManager == null) {
            gameManager = GameObject.Find("GameManagerObject").GetComponent<GameManager>();
        }

        Instance = this;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
        recognizer.Tapped += (args) =>
        {
            HandleAirTap();
        };
        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = GameManager.PC.transform.position;
        var gazeDirection = GameManager.PC.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }

    /// <summary>
    /// Handles the AirTap gesture. This is done by first checking the GameObject observed (if any)
    /// and responding accordingly.
    /// </summary>
    public void HandleAirTap() {
        // Send an OnSelect message to the focused object and its ancestors.
        if (FocusedObject != null && (FocusedObject.CompareTag("UI Element") || FocusedObject.CompareTag("Ball"))) {
            // Debug.Log("hit!");
            FocusedObject.SendMessageUpwards("OnSelect", SendMessageOptions.DontRequireReceiver);
        } else if (!GameManager.IsUISpawned) {
            // Spawn UI
            // Debug.Log("No UI");
            gameManager.SpawnUI();
        } else {
            // Debug.Log("Place item");
            GameManager.PC.Place();
        }
    }
}