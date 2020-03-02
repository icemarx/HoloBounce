using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlls : MonoBehaviour
{

    public float forceAmount = 1f;
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect()
    {
        Vector3 vec = this.transform.position - Camera.main.transform.position;
        vec = vec.normalized * forceAmount;
        rb.AddForce(vec, ForceMode.Impulse);
        rb.useGravity = true;
    }

    

}
