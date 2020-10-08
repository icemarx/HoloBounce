using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float forceAmount = 1f;
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// When selected, applies force to the Ball, simulating throwing the ball into <c>throwDirection</c>,
    /// based on the player and ball's position.
    /// </summary>
    public void OnSelect() {
        // compute and apply force of the toss
        Vector3 throwDirection = this.transform.position - Camera.main.transform.position;
        throwDirection = throwDirection.normalized * forceAmount;
        rb.AddForce(throwDirection, ForceMode.Impulse);

        // apply gravity
        rb.useGravity = true;
    }
}
