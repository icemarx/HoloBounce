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
        p.ball = Instantiate(this.ball);
        p.ball.SetActive(true);
        //p.ball.transform.SetParent(p.transform);
        p.PickUp(p.ball.transform);
    }
}
