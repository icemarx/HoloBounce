using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCredits : MonoBehaviour
{
    public GameObject creditsText;

    private void Start() {
        // if no credits are available, destroy this UI Element
        if (creditsText == null)
            Destroy(this);
    }

    /// <summary>
    /// When clicked, it sets the <c>creditsText</c> active state to the opposite
    /// of the previous state. This effectively works as a toggle.
    /// </summary>
    public void OnSelect() {
        creditsText.SetActive(!creditsText.activeSelf);
    }
}
