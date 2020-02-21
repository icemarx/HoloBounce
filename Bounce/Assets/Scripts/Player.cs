using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isHolding;

    public Transform holdTransform;
    
    void Start() {
        
    }

    private void OnTriggerEnter(Collider other) {
        // handle collision
        if (other.CompareTag("Ball")) {
            // Debug.Log("Ball hit");
            other.transform.SetParent(transform);
            other.transform.SetPositionAndRotation(holdTransform.position, holdTransform.localRotation);
            isHolding = true;
        }
    }
}
