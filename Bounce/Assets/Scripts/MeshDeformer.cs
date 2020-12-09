using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This ensures there is a MeshFilter component present on the object
[RequireComponent(typeof(MeshFilter))]
public class MeshDeformer : MonoBehaviour
{
    // How fast the deforming mesh returns to it's original position.
    public float springForce = 20f;

    // Factor of "calming down" when springin back.
    public float damping = 5f;

    // We need this so that the deformation is the same regardles of
    // scale of the mesh.
    float uniformScale = 1f;

    // The mesh we will be deforming.
    Mesh deformingMesh;

    // originalVertices are needed so that the ball can spring back
    // to it's previous shape.
    Vector3[] originalVertices, displacedVertices, vertexVelocities;

    void Start()
    {
        deformingMesh = GetComponent<MeshFilter>().mesh;
        originalVertices = deformingMesh.vertices;
        displacedVertices = new Vector3[originalVertices.Length];
        vertexVelocities = new Vector3[originalVertices.Length];


        for (int i = 0; i < displacedVertices.Length; i++)
        {
            displacedVertices[i] = originalVertices[i];
        }
    }

    void Update() {

    }


    public void AddDeformingForce(Vector3[] points, float force) {
        for(int i = 0; i < points.Length; i++) {
            Vector3 point = points[i];
            point = transform.InverseTransformPoint(point);

            for (int j = 0; j < displacedVertices.Length; j++) {
                AddForceToVertex(j, point, force);
            }
        }
    }

    void AddForceToVertex(int i, Vector3 point, float force) {
        Vector3 pointToVertex = displacedVertices[i] - point;
        pointToVertex *= uniformScale;
        float attenuatedForce = force / (1f + pointToVertex.sqrMagnitude);
        float velocity = attenuatedForce * Time.deltaTime;
        vertexVelocities[i] += pointToVertex.normalized * velocity;

        Debug.Log(vertexVelocities[i]);
    }
}
