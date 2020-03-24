using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxDistance = 20;

    public Transform holdTransform;     // Transform that designates where the items held in hands should be placed to
    public GameObject UI;
    private bool UISpawned;
    private GameObject heldItem;
    
    void Start() {
        UISpawned = false;
    }

    private void OnTriggerEnter(Collider other) {
        // handle collision
        if (other.CompareTag("Ball")) {
            // Debug.Log("Ball hit");
            PickUp(other.transform);
        }
    }

    /// <summary>
    /// Picks up the <c>item</c>, placing it in player's possession and moves it to <c>holdTransform</c> position, aka. hands
    /// </summary>
    /// <param name="item">Transform of the picked up item. NOTE: Item is ball, but may be changed to any item in the future </param>
    public void PickUp(Transform item) {
        // stop item from moving and rotating
        Rigidbody item_rb = item.GetComponent<Rigidbody>();
        item_rb.useGravity = false;
        item_rb.velocity = Vector3.zero;
        item_rb.angularVelocity = Vector3.zero;

        // place in "hands"
        item.SetParent(transform, false);
        item.SetPositionAndRotation(holdTransform.position, holdTransform.localRotation);
        heldItem = item.gameObject;
    }

    public void Place() {
        if(heldItem != null) {
            // detach and change position
            heldItem.transform.parent = null;
            heldItem.transform.position = transform.position + transform.forward;
            
            heldItem = null;
        }
    }

    public void OnSelect()
    {
        if (!UISpawned)
        {
            UISpawned = true;
            SpawnUI();
        }
    }

    public void SpawnUI()
    {
        Instantiate(UI);
    }
}
