using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

/// <note>
/// Should always be child GameObject of the Rescan UI element.
/// </note>
public class RescanQuality : MonoBehaviour {
    public SpatialMappingBase.LODType lod;      // Must be set in the inspecor view. Will override the one in SpatialMappingCollider

    /// <summary>
    /// Sets a new value for the Level of Detail of the <c>SpatialMappingCollider</c>
    /// <see cref="SpatialMappingCollider"/>
    /// <seealso cref="SpatialMappingBase.lodType"/>
    /// </summary>
    public void OnSelect() {
        Debug.Log("Set new LOD state: " + lod);
        transform.parent.GetComponent<RescanEnv>().spatialMappingScript.lod = lod;
    }
}
