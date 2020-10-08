using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBallOnSelect : MonoBehaviour {
    public GameManager gameManager;

    private void Awake() {
        /*
         * NOTE: this piece of code should be present whenever an Object should require
         * the GameManager at some point, in case it is not added in the editor.
         */
        if(gameManager == null) {
            gameManager = GameObject.Find("GameManagerObject").GetComponent<GameManager>();
        }
    }

    /// <summary>
    /// Creates a new ball, by destroying the old ball and then generating a new one, placing it to <c>PlayerController.heldItem</c>
    /// <see cref="PlayerController.heldItem"/>
    /// </summary>
    public void OnSelect() {
        // Destroy old ball
        GameObject ball = GameManager.GetFirstBall();
        GameManager.RemoveBall(ball);
        Destroy(ball);
        
        // create new ball
        GameObject newball = gameManager.CreateBall();
        newball.SetActive(true);
        
        // pass it to player
        GameManager.PC.PickUp(newball.transform);
    }
}
