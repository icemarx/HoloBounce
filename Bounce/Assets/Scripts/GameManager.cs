using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    /// <summary>
    /// Default ball used when no other options for CurrentBallType, such as at the start
    /// of the game or when there is an error changing it.
    /// </summary>
    [SerializeField]
    private GameObject DEFAULT_BALL_TYPE;

    /// <summary>
    /// Holds the array of all Materials that will be used by the bouncy ball.
    /// It should be refferenced by the variable <code>mat_index</code>.
    /// Default material should always be set to the zeroth (0th) index.
    /// </summary>
    [SerializeField]
    private Material[] BALL_MATERIAL;
    /// <summary>
    /// Holds the value of the currently chosen material. Set to 0 by default, in order to start
    /// with the default material. Private <c>m_mat_index</c> serves as the actual storage,
    /// and <c>mat_index</c> serves as as the retrievable value with automatic adjustments.
    /// </summary>
    [SerializeField]
    private int MatIndex {
        get { return m_MatIndex; }
        set {
            if (value < 0 || value >= BALL_MATERIAL.Length) m_MatIndex = 0;
            else m_MatIndex = value;
        }
    }
    public int m_MatIndex = 0;
    /// <summary>
    /// True if the UI is currently active, false otherwise
    /// </summary>
    public static bool IsUISpawned { get; private set; }

    /// <summary>
    /// Property <c>PC</c> represents the <c>PlayerController</c> script component of the
    /// active <c>(GameObject) Player</c> in the game. It is set at the start of the game
    /// and should not be changed. References to the <c>(GameObject) Player</c> should be
    /// made through this component.
    /// </summary>
    public static PlayerController PC { get; private set; }
    /// <summary>
    /// Property <c>balls</c> represents the List of all balls currently in game.
    /// It can only be written in within the GameManager with methods
    /// that add or remove balls from list.
    /// </summary>
    public static List<GameObject> Balls { get; private set; }
    /// <summary>
    /// The currently chosen type of ball. Should always be non-null. Mainly used for creating
    /// new balls. Should alway be selected from <c>BALL_TYPES</c>.
    /// <see cref="BALL_TYPES"/>
    /// </summary>
    public static GameObject CurrentBallType { get; private set; }
    /// <summary>
    /// Represents the user interface. It is a game object composed of childs with a
    /// <c>UI Element</c> tag.
    /// </summary>
    [SerializeField]
    public GameObject UI; //{ get; private set; }

    /// <summary>
    /// Finds the <c>Player</c> and all the balls with the Ball tag before the start of the game
    /// and inicialises <c>Player</c> and <c>Balls</c> properties.
    /// </summary>
    private void Awake() {
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
        Balls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));
        CurrentBallType = DEFAULT_BALL_TYPE;

        if (UI == null)
        {
            UI = GameObject.Find("UI");
        }
        // You can edit active state of the UI object from the editor.
        IsUISpawned = UI.activeSelf;
        Debug.Log(IsUISpawned);

    }

    /// <summary>
    /// Check for and handle balls that are too far away from Player.
    /// If a ball is too far from the player, it is picked up.
    /// <see cref="PlayerController.PickUp(Transform)"/>
    /// </summary>
    private void Update() {
        foreach (GameObject ball in GameManager.Balls) {
            // check distance from ball
            float distance = (PC.transform.position - ball.transform.position).magnitude;
            if (distance >= PC.maxDistance) {
                // handle balls out of range

                PC.PickUp(ball.transform);
            }
        }
    }

    /// <summary>
    /// Method <c>AddBall(GameObject ball)</c> adds the <c>ball</c> to the list <c>Balls</c>,
    /// if the <c>ball</c> has a Ball tag.
    /// </summary>
    /// <param name="ball">GameObject, representing a Ball</param>
    public static void AddBall(GameObject ball) {
        if (ball != null && ball.CompareTag("Ball"))
            Balls.Add(ball);
    }

    /// <summary>
    /// Method <c>CreateBall()</c> creates a new ball based on <c>CurrentBallType</c>, applies the current <c>Material</c> and
    /// adds it into the <c>Balls</c> list.
    /// <see cref="CurrentBallType"/>
    /// </summary>
    /// <returns>GameObject, representing the newly created ball.</returns>
    public GameObject CreateBall() {
        GameObject ball = Instantiate(CurrentBallType);

        // apply current Material
        ball.GetComponent<Renderer>().material = BALL_MATERIAL[MatIndex];

        AddBall(ball);
        return ball;
    }

    /// <summary>
    /// Method <c>RemoveBall(GameObject ball)</c> removes the <c>ball</c> from the <c>Balls</c> list,
    /// but does not destroy it.
    /// </summary>
    /// <param name="ball">GameObject that should be a ball from the <c>Balls</c> list</param>
    public static void RemoveBall(GameObject ball) {
        if (ball != null) {
            Balls.Remove(ball);
        }
    }

    /// <summary>
    /// Returns the first ball in the <c>Balls</c> list, if the list is not empty.
    /// </summary>
    /// <returns>Element at index 0 in the <c>Balls</c> list or null if list is empty</returns>
    public static GameObject GetFirstBall() {
        if (Balls.Count >= 0)
            return Balls[0];

        else return null;
    }

    /// <summary>
    /// Temporary method for incrementing materials used for the balls. It cycles
    /// through the list in one direction.
    /// <note>Should be rewritten in the future</note>
    /// </summary>
    public void IncrementBallColor() {
        MatIndex = (MatIndex + 1) % BALL_MATERIAL.Length;
    }


    /// <summary>
    /// Makes the UI active and places it infront of the player
    /// </summary>
    public void SpawnUI() {
        UI.SetActive(true);
        UI.transform.position = PC.transform.position + PC.transform.forward;
        UI.transform.LookAt(PC.transform);
        UI.transform.Rotate(new Vector3(0, 180, 0));

        IsUISpawned = true;
        Debug.Log("UI SPAWNED");
    }

    /// <summary>
    /// Makes the UI disappear, when being moved
    /// </summary>
    public void DespawnUI() {
        UI.SetActive(false);
        IsUISpawned = false;
        Debug.Log("UI DESPAWNED");
    }
}
