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

    public GameManager gameManager;

    // Start is called before the first frame update
    void Awake() {
        smCollider = gameObject.GetComponentInParent<SpatialMappingCollider>();
        smRenderer = gameObject.GetComponentInParent<SpatialMappingRenderer>();

        StartCoroutine("ScannEnvironment");

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
    /// Starts scanning the environment for real world objects and generates colliders for them.
    /// While scanning, the detected colliders are visualised by the renderer as well.
    /// Scanning is active for a number of seconds, designated by the value of <c>SCANNING_TIME</c>.
    /// After <c>SCANNING_TIME</c>, the <c>SpatialMappingCollider</c> and <c>SpatialMappingRender</c>
    /// freezes updates and stops visualisation to conserve processing power.
    /// </summary>
    /// <returns>Time needed to stop scanning in seconds</returns>
    IEnumerator ScannEnvironment() {
        // start scanning environment
        smCollider.freezeUpdates = false;
        smRenderer.freezeUpdates = false;
        // Apply visualisation
        smRenderer.renderState = SpatialMappingRenderer.RenderState.Visualization;

        Debug.Log("Started Scanning");


        // wait
        yield return new WaitForSeconds(SCANNING_TIME);


        // end scanning
        smCollider.freezeUpdates = true;
        smRenderer.freezeUpdates = true;
        // Remove Visualisation
        smRenderer.renderState = SpatialMappingRenderer.RenderState.Occlusion;

        Debug.Log("Stopped Scanning");
    }
}
