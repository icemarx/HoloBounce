using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float forceAmount = 1f;
    private Rigidbody rb;

    [SerializeField]
    private AudioSource bounceSound; // Reference to the bounce sound AudioSource on the ball
    private float bounce_volume; // Initial volume of the bounce sound audiosource

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        bounce_volume = bounceSound.volume;
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

    /// <summary>
    /// Called when the ball enters collision with another collider.
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        // if the ball does not collide with the player
        if (!collision.other.CompareTag("Player"))
        {
            // change pitch slightly based on velocity
            bounceSound.pitch = 1f + Mathf.Min(0.2f, 2f*rb.velocity.magnitude/100f);
            bounceSound.volume = bounce_volume + Mathf.Min(0.2f, 2f * rb.velocity.magnitude / 100f);
            Debug.Log(rb.velocity.magnitude);

            // play the bounce sound effect
            bounceSound.Play();
        }
    }
}
