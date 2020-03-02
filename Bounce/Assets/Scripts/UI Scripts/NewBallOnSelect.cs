using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBallOnSelect : MonoBehaviour
{
    public GameObject player;       // TODO: change to reference in Game Manager
    public GameObject ball;         // TODO: change to reference in Game Manager
    
    public void OnSelect() {
        Player p = player.GetComponent<Player>();
        GameObject.Destroy(p.ball);
        p.ball = Instantiate(ball);
        p.PickUp(p.ball.transform);
    }
}
