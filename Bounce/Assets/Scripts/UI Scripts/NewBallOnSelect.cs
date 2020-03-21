using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBallOnSelect : MonoBehaviour {
    public void OnSelect() {
        // Destroy old ball
        GameObject ball = GameManager.GetFirstBall();
        GameManager.RemoveBall(ball);
        Destroy(ball);

        ball = GameManager.CreateBall();
        ball.SetActive(true);
        
        //p.ball.transform.SetParent(p.transform);
        GameManager.Player.GetComponent<PlayerController>().PickUp(ball.transform);
    }
}
