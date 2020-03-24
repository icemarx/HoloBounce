using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Default ball used when no other options for CurrentBallType, such as at the start
    /// of the game or when there is an error changing it.
    /// </summary>
    [SerializeField]
    private GameObject DEFAULT_BALL_TYPE;

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
    /// Finds the <c>Player</c> and all the balls with the Ball tag before the start of the game
    /// and inicialises <c>Player</c> and <c>Balls</c> properties.
    /// </summary>
    private void Awake() {
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
        Balls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));
        CurrentBallType = DEFAULT_BALL_TYPE;
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
    /// Method <c>CreateBall()</c> creates a new ball based on <c>CurrentBallType</c> and
    /// adds it into the <c>Balls</c> list.
    /// <see cref="CurrentBallType"/>
    /// </summary>
    /// <returns>GameObject, representing the newly created ball.</returns>
    public static GameObject CreateBall() {
        GameObject ball = Instantiate(CurrentBallType);
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
}
