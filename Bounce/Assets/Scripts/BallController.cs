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

    [SerializeField]
    private AudioSource rollSound; // Reference to the roll sound AudioSource on the ball
    private float roll_volume; // Initial volume of the roll sound audiosource

    private bool isRolling; // If true, rolling sound effect should play

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        bounce_volume = bounceSound.volume;
        roll_volume = rollSound.volume;
    }

    private void Update()
    {
        // if the ball is not moving (or really slow) stop playing the rolling sound
         if (GameManager.muteSound || rb.velocity.magnitude < 0.01f)
        {
            rollSound.Stop();
            isRolling = false;
        }
         else
        {
            // change pitch and volume slightly based on velocity
            rollSound.pitch = 0.8f + Mathf.Min(0.3f, 2f * rb.velocity.magnitude / 100f);
            rollSound.volume = roll_volume + Mathf.Min(0.4f, 2f * rb.velocity.magnitude / 100f);
        }
    }

    /// <summary>
    /// When selected, applies force to the Ball, simulating throwing the ball into <c>throwDirection</c>,
    /// based on the player and ball's position.
    /// </summary>
    public void OnSelect() {
        // compute and apply force of the toss
        Vector3 throwDirection = this.transform.position - GameManager.PC.transform.position;
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
        if (!collision.collider.CompareTag("Player"))
        {
            // change pitch slightly based on velocity
            bounceSound.pitch = 1f + Mathf.Min(0.2f, 2f*rb.velocity.magnitude/100f);
            bounceSound.volume = bounce_volume + Mathf.Min(0.2f, 2f * rb.velocity.magnitude / 100f);

            // play the bounce sound effect
            if (!GameManager.muteSound)
                bounceSound.Play();
        }
    }

    /// <summary>
    /// Called when the ball stays in collision with an object e.g. rolling on the floor.
    /// </summary>
    private void OnCollisionStay(Collision collision)
    {
        // if the ball does not collide with the player and is moving
        if (!collision.collider.CompareTag("Player") && rb.velocity.magnitude > 0.1f)
        {
            // play the rolling sound
            if (!isRolling && !GameManager.muteSound)
            {
                rollSound.Play();
                isRolling = true;
            }
        }
    }


    /// <summary>
    /// Called when the ball exits collision with an object e.g. stops rolling on the floor.
    /// </summary>
    private void OnCollisionExit(Collision collision)
    {
        // stop the rolling sound
        if (isRolling)
        {
            rollSound.Stop();
            isRolling = false;
        }
    }
}
