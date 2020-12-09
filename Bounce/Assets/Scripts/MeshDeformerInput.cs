using UnityEngine;

public class MeshDeformerInput : MonoBehaviour
{
    /// <summary>
    /// Force with which the ball will be transofrmet.
    /// <summary>
    public float force = 10f;
    public float forceOffset = .1f;

    MeshDeformer deformer;
    void Start() {
        deformer = GetComponent<MeshDeformer>();
    }

    void Update() {

    }

    void OnCollisionEnter(Collision collision)
    {
        // Array which stores the contacPoints.
        ContactPoint[] contacts = new ContactPoint[50];
        int numOfContacts = collision.GetContacts(contacts);

        HandleCollision(contacts, numOfContacts);
    }

    void HandleCollision(ContactPoint[] contacts, int numOfContacts) {
        Vector3[] points = new Vector3[numOfContacts];

        // Might be better to send only one point and call the function
        // for each point seperatly.
        if (deformer) {
            for (int i = 0; i < numOfContacts; i++) {
                points[i] = contacts[i].point + (contacts[i].normal * forceOffset);
            }
            deformer.AddDeformingForce(points, force); 
        }
    }
}
