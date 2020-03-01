using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBallOnSelect : MonoBehaviour
{

    public GameObject ball;
    public Transform holdTransform;
    private GameObject held;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect()
    {
        ball = Instantiate(ball);
        Transform t = ball.transform;
        // stop ball from moving
        Rigidbody trgbd = t.GetComponent<Rigidbody>();
        trgbd.useGravity = false;
        trgbd.velocity = Vector3.zero;
        trgbd.angularVelocity = Vector3.zero;

        // place in "hands"
        t.SetParent(transform);
        t.SetPositionAndRotation(holdTransform.position, holdTransform.localRotation);
        held = t.gameObject;
        // Still need to figure out wheather the ball is in your hands or not
    }
}
