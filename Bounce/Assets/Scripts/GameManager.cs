using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <value>
    /// Property <c>player</c> represents the active player in the game.
    /// it is set at the start of the game and should not be changed.
    /// </value>
    public GameObject Player { get; private set; }

    private void Awake() {
        Player = GameObject.Find("Player");
    }
}
