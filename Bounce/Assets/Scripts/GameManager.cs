using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <value>
    /// Property <c>player</c> represents the active player in the game.
    /// It is set at the start of the game and should not be changed.
    /// </value>
    public GameObject Player { get; private set; }
    /// <summary>
    /// Property <c>balls</c> represents the List of all balls currently in game.
    /// It can only be written in within the GameManager with methods
    /// that add or remove balls from list.
    /// </summary>
    public List<GameObject> Balls { get; private set; }

    /// <summary>
    /// Finds the <c>Player</c> and all the balls with the Ball tag before the start of the game
    /// and inicialises <c>Player</c> and <c>Balls</c> properties.
    /// </summary>
    private void Awake() {
        Player = GameObject.Find("Player");
        Balls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));
    }

    /// <summary>
    /// Method <c>AddBall(GameObject ball)</c> adds the <c>ball</c> to the list <c>Balls</c>,
    /// if the <c>ball</c> has a Ball tag.
    /// </summary>
    /// <param name="ball">GameObject, representing a Ball</param>
    public void AddBall(GameObject ball) {
        if (ball != null && ball.CompareTag("Ball"))
            Balls.Add(ball);
    }

    /// <summary>
    /// Method <c>RemoveBall(GameObject ball)</c> removes the <c>ball</c> from the <c>Balls</c> list,
    /// but does not destroy it.
    /// </summary>
    /// <param name="ball">GameObject that should be a ball from the <c>Balls</c> list</param>
    public void RemoveBall(GameObject ball) {
        if (ball != null) {
            Balls.Remove(ball);
        }
    }

    /// <summary>
    /// Returns the first ball in the <c>Balls</c> list, if the list is not empty.
    /// </summary>
    /// <returns>Element at index 0 in the <c>Balls</c> list or null if list is empty</returns>
    public GameObject GetFirstBall() {
        if (Balls.Count >= 0)
            return Balls[0];

        else return null;
    }
}
