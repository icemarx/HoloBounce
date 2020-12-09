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
        collision.GetContacts(contacts);

        deformer.AddDeformingForce(contacts, force); 
    }
}
