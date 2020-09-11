using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class SpatialMappingScript : MonoBehaviour
{
    [SerializeField]
    private float SCANNING_TIME = 10f;
    private SpatialMappingCollider smCollider;
    private SpatialMappingRenderer smRenderer;

    // Start is called before the first frame update
    void Start() {
        smCollider = gameObject.GetComponentInParent<SpatialMappingCollider>();
        smRenderer = gameObject.GetComponentInParent<SpatialMappingRenderer>();

        StartCoroutine("ScannEnvironment");

    }

    IEnumerator ScannEnvironment() {
        // start scanning environment
        smCollider.freezeUpdates = false;
        smRenderer.freezeUpdates = false;
        // Debug.Log("Started Scanning");

        // wait
        yield return new WaitForSeconds(SCANNING_TIME);

        // end scanning
        smCollider.freezeUpdates = true;
        smRenderer.freezeUpdates = true;
        // Debug.Log("Stopped Scanning");
    }
}
