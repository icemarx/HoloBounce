using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescanEnv : MonoBehaviour {
    public GameManager gameManager;
    public SpatialMappingScript spatialMappingScript;

    private void Awake() {
        /*
         * NOTE: this piece of code should be present whenever an Object should require
         * the GameManager at some point, in case it is not added in the editor.
         */
        if (gameManager == null) {
            gameManager = GameObject.Find("GameManagerObject").GetComponent<GameManager>();
        }
    }
    
    /// <summary>
    /// Call the <c>Rescan</c> method of the <c>SpatialMappingScript</c>.
    /// <see cref="SpatialMappingScript.Rescan"/>
    /// </summary>
    public void OnSelect() {
        spatialMappingScript.Rescan();
    }
}
