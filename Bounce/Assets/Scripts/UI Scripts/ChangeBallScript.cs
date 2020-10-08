using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBallScript : MonoBehaviour
{
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
    /// Triggers changing ball color.
    /// Current implementation uses a fixed list of colors through which it cycles.
    /// After pressing, a new ball must be created, via <c>NewBall</c> UI element.
    /// <see cref="GameManager.IncrementBallColor"/>
    /// </summary>
    public void OnSelect() {
        gameManager.IncrementBallColor();

        Debug.Log("Ball color changed");
    }
}
