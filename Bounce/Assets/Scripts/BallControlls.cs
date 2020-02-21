using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlls : MonoBehaviour
{

    public float forceAmount = 1f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector3 vec = this.transform.position - Camera.main.transform.position;
        vec = vec.normalized * forceAmount;
        rb.AddForce(vec, ForceMode.Impulse);
        rb.useGravity = true;
    }

}
