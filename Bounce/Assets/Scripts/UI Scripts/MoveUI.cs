using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUI : MonoBehaviour {
    public GameManager gameManager;

    private void Awake() {
        /*
         * NOTE: this piece of code should be present whenever an Object should require
         * the GameManager at some point, in case it is not added in the editor.
         */
        if (gameManager == null) {
            gameManager = GameObject.Find("GameManagerObject").GetComponent<GameManager>();
        }
    }

    /// <summary>
    /// Hides the UI until it is spawned again by airtapping at empty space.
    /// <see cref="GameManager.DespawnUI"/>
    /// <seealso cref="GazeGestureManager.recognizer"/>
    /// </summary>
    public void OnSelect() {
        gameManager.DespawnUI();
    }
}
