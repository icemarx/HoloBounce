using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isHolding;
    public float maxDistance = 20;

    public Transform holdTransform;
    public GameObject ball;
    
    void Start() {
        
    }

    void Update() {
        // check distance from ball
        float distance = (transform.position - ball.transform.position).magnitude;
        if (distance >= maxDistance) {
            PickUp(ball.transform);
        }
    }

    private void OnTriggerEnter(Collider other) {
        // handle collision
        if (other.CompareTag("Ball")) {
            // Debug.Log("Ball hit");
            PickUp(other.transform);
        }
    }

    public void PickUp(Transform t) {
        t.SetParent(transform);
        t.SetPositionAndRotation(holdTransform.position, holdTransform.localRotation);
        isHolding = true;
    }
}
