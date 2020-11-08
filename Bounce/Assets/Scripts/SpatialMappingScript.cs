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
    public SpatialMappingBase.LODType lod;

    public GameManager gameManager;

    bool isScanning = false;

    // Start is called before the first frame update
    void Awake() {  
        smCollider = gameObject.GetComponentInParent<SpatialMappingCollider>();
        smRenderer = gameObject.GetComponentInParent<SpatialMappingRenderer>();
        lod = smCollider.lodType;

        StartCoroutine("ScanEnvironment");

        /*
        if (gameManager == null)
        {
            gameManager = GameObject.Find("GameManagerObject").GetComponent<GameManager>();
        }

        if (GameManager.IsUISpawned)
        {
            gameManager.SpawnUI();
        }
        */
    }

    /// <summary>
    /// Deletes the old scanned environment and starts the coroutine <c>ScanEnvironment</c> to
    /// scan it again.
    /// </summary>
    public void Rescan() {
        if (!isScanning) {
            // remove old scan
            // TODO: check if the Surface Parent object is correct
            foreach (Transform child in smCollider.surfaceParent.transform) {
                Destroy(child.gameObject);
            }

            // scan again
            StartCoroutine("ScanEnvironment");
        }
    }

    /// <summary>
    /// Starts scanning the environment for real world objects and generates colliders for them.
    /// While scanning, the detected colliders are visualised by the renderer as well.
    /// Scanning is active for a number of seconds, designated by the value of <c>SCANNING_TIME</c>.
    /// After <c>SCANNING_TIME</c>, the <c>SpatialMappingCollider</c> and <c>SpatialMappingRender</c>
    /// freezes updates and stops visualisation to conserve processing power.
    /// </summary>
    /// <returns>Time needed to stop scanning in seconds</returns>
    IEnumerator ScanEnvironment() {
        // start scanning environment
        isScanning = true;
        smCollider.freezeUpdates = false;
        smRenderer.freezeUpdates = false;
        // Apply visualisation
        smRenderer.renderState = SpatialMappingRenderer.RenderState.Visualization;
        smCollider.lodType = lod;

        Debug.Log("Started Scanning");


        // wait
        yield return new WaitForSeconds(SCANNING_TIME);


        // end scanning
        smCollider.freezeUpdates = true;
        smRenderer.freezeUpdates = true;
        // Remove Visualisation
        smRenderer.renderState = SpatialMappingRenderer.RenderState.Occlusion;
        isScanning = false;

        Debug.Log("Stopped Scanning");
    }
}
