using UnityEngine;

public class MeshDeformerInput : MonoBehaviour
{
    /// <summary>
    /// Force with which the ball will be transofrmet.
    /// <summary>
    public float force = 10f;
    public float forceOffset = .1f;

    void Start() {
            
    }

    void Update() {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ball colided with something");

        ContactPoint[] contacts = new ContactPoint[50];
        Debug.Log(collision.GetContacts(contacts));
    }
}
