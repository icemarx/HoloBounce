using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxDistance = 20;

    public Transform holdTransform;
    public GameObject ball;
    public GameObject UI;
    private bool UISpawned;
    private GameObject held;
    
    void Start() {
        UISpawned = false;
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
        // stop ball from moving
        Rigidbody trgbd = t.GetComponent<Rigidbody>();
        trgbd.useGravity = false;
        trgbd.velocity = Vector3.zero;
        trgbd.angularVelocity = Vector3.zero;

        // place in "hands"
        t.SetParent(transform, false);
        t.SetPositionAndRotation(holdTransform.position, holdTransform.localRotation);
        held = t.gameObject;
    }

    public void Place() {
        if(held != null) {
            // detach and change position
            held.transform.parent = null;
            held.transform.position = transform.position + transform.forward;
            
            held = null;
        }
    }

    public void OnSelect()
    {
        if (!UISpawned)
        {
            UISpawned = true;
            SpawnUI();
        }
    }

    public void SpawnUI()
    {
        Instantiate(UI);
    }
}
